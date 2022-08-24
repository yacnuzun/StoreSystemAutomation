using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        static string uploadPath = @"C:\Users\yacnu\source\repos\StoreSystemAutomation\WebUI\wwwroot\startbootstrap-shop-homepage-gh-pages\Img\";


        public static string Add(IFormFile file)
        {
            string imgPath = "startbootstrap-shop-homepage-gh-pages/Img/";
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var uploading = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(uploading);
                }
            }
            var result = newPath(file);
            File.Move(sourcepath, uploadPath + result);
            return imgPath+result;
        }
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file).ToString();
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var newPath = DateTime.Now.ToString("HH/mm/ss MM/dd/yyyy ") + Guid.NewGuid().ToString() + fileExtension;

            string result = Regex.Replace(newPath, "[/|:| ]", "-");

            //string result = $@"{path}\{newPath}";
            return result;
        }

    }
}
