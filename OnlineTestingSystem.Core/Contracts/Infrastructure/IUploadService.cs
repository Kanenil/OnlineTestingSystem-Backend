using Microsoft.AspNetCore.Http;
using OnlineTestingSystem.Application.Models.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Contracts.Infrastructure
{
    public interface IUploadService
    {
        Task<UploadFileResult> UploadFileAsync(IFormFile file);
        Task RemoveFileAsync(string fileUrl);
    }
}
