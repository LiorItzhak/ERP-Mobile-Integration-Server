using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CrossLayersUtils;
using DataAccessLayer;

namespace LogicLib.Services
{
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
        Task<Stream> GetAttachmentAsync(string filename);
        Task<byte[]> GetBitmapAsync(string filename);

        Task<IEnumerable<FileContainer>> PostAttachmentsAsync(IEnumerable<FileContainer> files);

        Stream GetPdfForObjectAsync(string objectKey, DateTime? createdAfter = null);
    }

    public class FileService : IFileService
    {
        private readonly IDalService _dalService;
        private const string BitmapPath = @"\\cm-sap-server\B1_SHR\BITMAP\"; //TODO
        public const string AttachmentPath = @"\\cm-sap-server\B1_SHR\Attachments\";

        public FileService(IDalService dalService)
        {
            _dalService = dalService;
        }

        public async Task<Stream> GetAttachmentAsync(string filename)
        {
            var filepath = AttachmentPath + filename;
            if (!File.Exists(filepath)) throw new NotFoundException($"file {filename} Not found -- {filepath}");
            return await Task.Run(() => File.OpenRead(filepath));
        }

        public async Task<byte[]> GetBitmapAsync(string filename)
        {
            var filepath = BitmapPath + filename;
            if (!File.Exists(filepath)) throw new NotFoundException($"file {filename} Not found :{filepath}");
            return await File.ReadAllBytesAsync(filepath);
        }

        public async Task<IEnumerable<FileContainer>> PostAttachmentsAsync(IEnumerable<FileContainer> files)
        {
            foreach (var file in files)
            {
                //Extract file name from whatever was posted by browser
                var filepath = AttachmentPath + file.Name;

                // If file with same name exists delete it
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }

                // Create new local file and copy contents of uploaded file
                await using var localFile = File.OpenWrite(filepath);
                await using var uploadedFile = file.FileStream;
                uploadedFile.CopyTo(localFile);
            }

            return null; //TODO
        }

        public  Stream GetPdfForObjectAsync(string objectKey, DateTime? createdAfter)
        {
            //TODO specific for SAP B1-> generalize it
            var file = Directory.GetFiles(AttachmentPath, "*.pdf", SearchOption.TopDirectoryOnly)
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
    }
}