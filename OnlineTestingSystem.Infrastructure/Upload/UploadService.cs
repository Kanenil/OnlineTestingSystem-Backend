using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using OnlineTestingSystem.Application.Constants;
using OnlineTestingSystem.Application.Contracts.Infrastructure;
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

        public async Task<string> UploadFileAsync(IFormFile file)
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

            return $"https://${AmazonS3.BasketName}.s3.${AmazonS3.Region}.amazonaws.com/${fileName}";
        }

    }
}
