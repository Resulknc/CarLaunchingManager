using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.CloudinaryOperations
{
    public class CloudinaryManager : ICloudinaryService
    {
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private readonly Cloudinary _cloudinary;
       

        public CloudinaryManager(IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;

            Account account = new Account(

                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
                );

            _cloudinary = new Cloudinary(account);
        }

        public IDataResult<ImageUploadResult> AddPhoto(IFormFile file)
        {
            var uploadedResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadedParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill")
                };

                uploadedResult = _cloudinary.Upload(uploadedParams);

                return new SuccessDataResult<ImageUploadResult>(uploadedResult);
            }

               return new ErrorDataResult<ImageUploadResult>(uploadedResult);
           

            
        }
    }
}
