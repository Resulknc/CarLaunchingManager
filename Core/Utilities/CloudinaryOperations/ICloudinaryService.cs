using CloudinaryDotNet.Actions;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.CloudinaryOperations
{
    public interface ICloudinaryService
    {
       IDataResult<ImageUploadResult>  AddPhoto(IFormFile file);
    }
}
