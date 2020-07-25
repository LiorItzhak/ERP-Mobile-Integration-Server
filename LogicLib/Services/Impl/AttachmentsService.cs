using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrossLayersUtils;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Geocoding;
using Microsoft.Extensions.Logging;

namespace LogicLib.Services.Impl
{
    public class AttachmentsService : IAttachmentsService
    {
        private readonly IDalService _dalService;
        private readonly ILogger<IAttachmentsService> _logger;

        public AttachmentsService(IDalService dalService, ILogger<IAttachmentsService> logger)
        {
            _dalService = dalService;
            _logger = logger;
        }

        public async Task<Attachment> GetByKeyAsync(int attachmentsCode, int num)
        {
            using var uow = _dalService.CreateUnitOfWork();
            return await uow.Attachments.FindByIdAsync(new IAttachmentRepository.AttachmentKey
                {Code = attachmentsCode, Num = num});
        }


        public async Task<List<Attachment>> GetAttachments(int attachmentsCode, DateTime? createdAfterDate = null)
        {
            using var uow = _dalService.CreateUnitOfWork();
            var r = await uow.Attachments.FindAllAsync(x => x.AttachmentsCode == attachmentsCode &&
                                                            (createdAfterDate.HasValue == false ||
                                                             x.CreationDate > createdAfterDate),
                PageRequest.Of(0, int.MaxValue));

            return r;
        }


        public async Task<IEnumerable<Attachment>> CreateNewAttachments(IEnumerable<FileContainer> files,
            int? attachmentsCode,
            CancellationToken cancellationToken = default)
        {
            var filesToDelete = new List<string>(); //contains files to delete when error occurred
            try
            {
                var fileContainers = files as FileContainer[] ?? files.ToArray();
                if (!fileContainers.Any())
                    throw new IllegalArgumentException("must have at least 1 file");
                //write files to server's disk
                foreach (var file in fileContainers)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    //Extract file name from whatever was posted by browser
                    var filepath = FileService.AttachmentPath + file.Name;

                    // If file with same name exists delete it
                    if (File.Exists(filepath))
                    {
                        _logger.LogInformation($"Modifying existing file: {filepath}");
                        File.Delete(filepath);
                    }
                    else
                    {
                        filesToDelete.Add(filepath); //mark as new file -> must be deleted on error
                        _logger.LogInformation($"Saving new file: {filepath}");
                    }

                    // Create new local file and copy contents of uploaded file
                    await using var localFile = File.OpenWrite(filepath);
                    await using var uploadedFile = file.FileStream;
                    uploadedFile.CopyTo(localFile);
                }

                var attachments = fileContainers.Select(file => new Attachment
                {
                    AttachmentsCode = attachmentsCode,
                    Path = FileService.AttachmentPath.Remove(FileService.AttachmentPath.Length - 1),
                    FileName = file.Name.Split(".")[0],
                    Ext = file.Name.Split(".")[1]
                }).ToList();
                using var uow = _dalService.CreateUnitOfWork();
                if (attachmentsCode.HasValue || attachments.Count == 1)
                {
                    attachments = await uow.Attachments.AddAsync(attachments);
                }
                else
                {
                    var firstAtt = await uow.Attachments.AddAsync(attachments.First());
                    attachments.ForEach(x => x.AttachmentsCode = firstAtt.AttachmentsCode);
                    attachments = await uow.Attachments.AddAsync(attachments.Skip(1).ToList());
                    attachments.Insert(0, firstAtt);
                }

                await uow.CompleteAsync(cancellationToken);
                return attachments;
            }
            catch
            {
                //if error occurred - delete inserted files
                filesToDelete = filesToDelete.Where(File.Exists).ToList();
                filesToDelete.ForEach(File.Delete);
                if (filesToDelete.Count > 0)
                    _logger.LogInformation($"New Files Deleted: {filesToDelete.Aggregate((s1, s2) => $"{s1},{s2}")}");
                throw;
            }
        }
    }
}