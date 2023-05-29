using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using OnlineTestingSystem.Application.Constants;
using OnlineTestingSystem.Application.Contracts.Infrastructure;
using OnlineTestingSystem.Application.Exeptions;
using OnlineTestingSystem.Application.Models.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Infrastructure.Upload
{
    public class UploadService : IUploadService
    {
        private IAmazonS3 _client;

        public UploadService(IAmazonS3 client)
        {
            _client = client;
        }

        public async Task RemoveFileAsync(string fileUrl)
        {
            Uri uri = new Uri(fileUrl);
            string filename = uri.Segments[1];

            var request = new DeleteObjectRequest
            {
                BucketName = AmazonS3.BasketName,
                Key = filename,
            };
            var response = await _client.DeleteObjectAsync(request);

            if (response.HttpStatusCode != System.Net.HttpStatusCode.NoContent)
                throw new Exception("While deleting file, something went wrong!");
        }

        public async Task<UploadFileResult> UploadFileAsync(IFormFile file)
        {
            var fileName =  String.Concat(Path.GetRandomFileName(), Path.GetExtension(file.FileName));

            var request = new PutObjectRequest
            {
                BucketName = AmazonS3.BasketName,
                Key = fileName,
                InputStream = file.OpenReadStream(),
            };

            var response = await _client.PutObjectAsync(request);
            if (response.HttpStatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("While saving file, something went wrong!");

            return new()
            {
                FileUrl = $"https://{AmazonS3.BasketName}.s3.{AmazonS3.Region}.amazonaws.com/{fileName}"
            };
        }

    }
}
