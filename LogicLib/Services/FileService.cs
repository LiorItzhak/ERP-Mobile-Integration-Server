using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrossLayersUtils;
using Microsoft.Extensions.Logging;

namespace LogicLib.Services
{
    public class FileServiceSettings
    {
        public string BaseFolder { get; set; }
    }
    public class FileContainer
    {
        public Stream FileStream { get; set; }
        public string Name { get; set; }
        public string ContentDisposition { get; set; }
        public long Length { get; set; }
        public string ContentType { get; set; }
    }

    public interface IFileService
    {
        Task<Stream> GetFileAsync(string fileKey);
        [Obsolete("OLD API ")]
        Task<byte[]> GetBitmapAsync(string fileKey);

        Task<IEnumerable<string>> SaveFilesAsync(IEnumerable<FileContainer> files,
            bool allowOverwrite = false,
            CancellationToken cancellationToken = default);

        Stream GetPdfForObjectAsync(string objectKey, DateTime? createdAfter = null);

        String ResolveFullLocalPath(String fileKey);
    }

    public class FileService : IFileService
    {
        private readonly FileServiceSettings _settings;
        private readonly ILogger<FileService> _logger;
        private const string BitmapPath = @"\\cm-sap-server\B1_SHR\BITMAP"; //TODO

        public FileService(FileServiceSettings settings, ILogger<FileService> logger)
        {
            _settings = settings;
            _logger = logger;
        }


        public async Task<Stream> GetFileAsync(string fileKey)
        {
            var filepath =Path.Join(_settings.BaseFolder, fileKey);
            if (!File.Exists(filepath)) throw new NotFoundException($"file {fileKey} Not found -- {filepath}");
            return await Task.Run(() => File.OpenRead(filepath));
        }

        
        public async Task<byte[]> GetBitmapAsync(string fileKey)
        {
            var filepath = Path.Join(BitmapPath, fileKey);
            if (!File.Exists(filepath)) throw new NotFoundException($"file {fileKey} Not found :{filepath}");
            return await File.ReadAllBytesAsync(filepath);
        }

        
        // TODO - use transactional file-system
        public async Task<IEnumerable<string>> SaveFilesAsync(IEnumerable<FileContainer> files,
            bool allowOverwrite ,
            CancellationToken cancellationToken)
        {
            var fileContainers = files as FileContainer[] ?? files.ToArray();
            if (!fileContainers.Any())
                throw new IllegalArgumentException("must have at least 1 file");

            var filesStreamsWithKeys = fileContainers
                .Select(f => new {file = f, fullLocalPath = ResolveFullLocalPath(f.Name)}).ToArray();

            
            //contains files to restore when error occurred
            var modifiedFilesToBackup = filesStreamsWithKeys
                .Where(x => File.Exists(x.fullLocalPath))
                .Select(x => new
                {
                    tmpFullLocalPath = Path.GetTempFileName(), originFullPath = x.fullLocalPath
                }).ToArray();

            if (modifiedFilesToBackup.Length > 0 && allowOverwrite == false)
            {
                var msg = modifiedFilesToBackup
                    .Select(x => x.originFullPath)
                    .Aggregate((x1, x2) => $"{x1},{x2}");
                throw new InvalidOperationException($"1 or more files already exists, cant overwrite - {msg}");
            }
            
            // backup existing files 
            foreach (var f in modifiedFilesToBackup)
            {
                _logger.LogInformation($"Backup file:{f.originFullPath} -> {f.tmpFullLocalPath}");
                File.Copy(f.originFullPath, f.tmpFullLocalPath,true);
                File.Delete(f.originFullPath);
                cancellationToken.ThrowIfCancellationRequested();
            }
            
            try
            {
                foreach (var fk in filesStreamsWithKeys)
                {
                    // Create new local file and copy contents of uploaded file
                    _logger.LogInformation($"Writing file:{fk.fullLocalPath}");
                    await using var localFile = File.OpenWrite(fk.fullLocalPath);
                    await using var uploadedFile = fk.file.FileStream;
                    cancellationToken.ThrowIfCancellationRequested();
                    await uploadedFile.CopyToAsync(localFile, cancellationToken);
                    _logger.LogInformation($"File:{fk.fullLocalPath} - Created!");

                }
            }
            catch
            {
                _logger.LogInformation($"Upload files failed - start deleting and restoring files...");

                var fileToDelete = filesStreamsWithKeys
                    .Select(x=>x.fullLocalPath)
                    .Where(File.Exists)
                    .Select(x =>
                    {
                        File.Delete(x);
                        return x;
                    }).ToArray();
                if (fileToDelete.Any())
                    _logger.LogInformation($"Deleted Files: {fileToDelete.Aggregate((s1, s2) => $"{s1},{s2}")}");
                
                //if error occurred - restore modified files
                var filesToRestore = modifiedFilesToBackup
                    .Where(x => File.Exists(x.tmpFullLocalPath))
                    .Select(x =>
                    {
                        if (File.Exists(x.originFullPath))
                            File.Delete(x.originFullPath);
                        File.Copy(x.tmpFullLocalPath, x.originFullPath);
                        File.Delete(x.tmpFullLocalPath);
                        return x.originFullPath;
                    }).ToArray();
                if (filesToRestore.Any())
                    _logger.LogInformation(
                        $"Modified Files Restored: {filesToRestore.Aggregate((s1, s2) => $"{s1},{s2}")}");
                
                throw;
            }

            // Remove Temporary files on background thread (nonblocking)
            // ReSharper disable once MethodSupportsCancellation
            Task.Run(() =>
            {
                _logger.LogInformation($"Deleting tmp files");
                // remove tmp files 
                foreach (var f in modifiedFilesToBackup)
                {
                    if (File.Exists(f.tmpFullLocalPath))
                        File.Delete(f.tmpFullLocalPath);
                }
            });
          
            
            return filesStreamsWithKeys.Select(x => x.file.Name); 
        }

        public Stream GetPdfForObjectAsync(string objectKey, DateTime? createdAfter)
        {
            //TODO specific for SAP B1-> generalize it
            var file = Directory.GetFiles(_settings.BaseFolder, "*.pdf", SearchOption.TopDirectoryOnly)
                .Select(x => new
                    {path = x, parts = Path.GetFileNameWithoutExtension(x).Split("_").Skip(1).ToArray() /*skip type*/})
                .Where(x => x.parts.Length == 3)
                .Where(x => x.parts[0] == objectKey)
                .Select(x => new {x.path, parts = x.parts.Skip(1).ToArray()})
                .Where(x => x.parts.All(p => p.All(char.IsDigit)))
                .Where(x => x.parts[0].Length == 8 /*date*/ && x.parts[1].Length == 6 /*time*/)
                .Select(x => new
                {
                    x.path,
                    year = Convert.ToInt16(x.parts[0].Substring(0, 4)),
                    month = Convert.ToInt16(x.parts[0].Substring(4, 2)),
                    day = Convert.ToInt16(x.parts[0].Substring(6, 2)),
                    hours = Convert.ToInt16(x.parts[1].Substring(0, 2)),
                    mins = Convert.ToInt16(x.parts[1].Substring(2, 2)),
                    sec = Convert.ToInt16(x.parts[1].Substring(4, 2)),
                })
                .Select(x => new
                    {Path = x.path, CreationTimestamp = new DateTime(x.year, x.month, x.day, x.hours, x.mins, x.sec)})
                .Where(x => createdAfter.HasValue == false || x.CreationTimestamp > createdAfter)
                .OrderByDescending(x => x.CreationTimestamp).FirstOrDefault();
            if (file == null) throw new NotFoundException($"PDF for objectKey:{objectKey} don't exist");
            return File.OpenRead(file.Path);
        }

        public string ResolveFullLocalPath(string fileKey)
        {
            return Path.Join(_settings.BaseFolder, fileKey);
        }
    }
}