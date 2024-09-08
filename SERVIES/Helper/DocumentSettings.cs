using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIES.Helper
{
    public class DocumentSettings

    {
        public static string UploadFile(IFormFile file, string folderName)           //in wwwroot (folder=>files=>images)

        {
            //1-get folder path

            var folderpath=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files" , folderName);

            //2-get file name

            var filename = $"{Guid.NewGuid()} - {file.FileName}";                    //uniqe name (عشان مينفعش ارفع فايلين بنفس الاسم )

            //3-combine folderpath + filepath

            var filepath=Path.Combine(folderpath, filename);

            //4-save file

            using var filestraem = new FileStream(filepath,FileMode.Create);   //filestream => (class للتعامل مع الفايلات)
            file.CopyTo(filestraem);                                              //filemood => انواع 
            return filename;      




        }







    }
}
