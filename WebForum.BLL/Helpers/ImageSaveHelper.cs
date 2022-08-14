using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace WebForum.BLL.Helpers
{
    internal static class ImageSaveHelper
    {
        private static int index = 0;
        private static readonly string dot = ".";

        private static string Sufix
        {
            get
            {
                return "(" + index.ToString() + ")";
            }
        }

        private static readonly string baseFolder = "wwwroot/";

        public static string SaveImageAndGeneratePath(IFormFile image, string directory)
        {
            string[] imageName = image.FileName.Split(".");

            var format = imageName[1];
            string name = imageName[0];

            directory = baseFolder + directory;
            var path = directory + name + dot + format;
            var template = path;


            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            while (File.Exists(template))
            {
                index++;
                template = directory + name + Sufix + dot + format;
            }

            using (var fileStream = new FileStream(template, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            return template.Remove(0, baseFolder.Length);
        }

        public static void DeleteImage(string imagePath)
        {
            var targetDirectory = baseFolder + imagePath;

            if (File.Exists(targetDirectory))
            {
                File.Delete(targetDirectory);
            }
        }

    }


}
