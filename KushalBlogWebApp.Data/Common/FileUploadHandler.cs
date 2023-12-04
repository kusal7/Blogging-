using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KushalBlogWebApp.Data.Common
{
    /// <summary>
    /// The file upload handler.
    /// </summary>
    public class FileUploadHandler
    {

        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <param name="hostEnv">The host env.</param>
        /// <param name="folderPath">The folder path.</param>
        /// <param name="file">The file.</param>
        /// <returns>A Task.</returns>
        public static async Task<string> UploadFile(IHostingEnvironment hostEnv, string folderPath, IFormFile file)
        {
            if (!Directory.Exists("" + hostEnv.WebRootPath + "\\" + folderPath))
                Directory.CreateDirectory("" + hostEnv.WebRootPath + "\\" + folderPath);

            if (file == null) return "/" + folderPath;

            //folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            var fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file.FileName);
            var fileExtension = System.IO.Path.GetExtension(file.FileName);
            folderPath += fileNameWithoutExtension + "_" + DateTime.UtcNow.ToString("yyyy_MM_dd_HH_mm_ss_ffff") + fileExtension;

            var serverFolder = Path.Combine(hostEnv.WebRootPath, folderPath);
            await using (var fileStream = new FileStream(serverFolder, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
                fileStream.Flush();
            }
            return "/" + folderPath;
        }

        /// <summary>
        /// Uploads the file user k y c.
        /// </summary>
        /// <param name="baseUrl">The base url.</param>
        /// <param name="folderPath">The folder path.</param>
        /// <param name="file">The file.</param>
        /// <returns>A Task.</returns>
        public static async Task<string> UploadFileUserKYC(string baseUrl, string folderPath, IFormFile file)
        {
            if (!Directory.Exists(baseUrl))
            {
                Directory.CreateDirectory(baseUrl);
            }




            var targetFolderPath = Path.Combine(baseUrl, folderPath);

            if (file == null)
            {
                return "/" + folderPath;
            }

            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
            var fileExtension = Path.GetExtension(file.FileName);
            var uniqueFileName = $"{fileNameWithoutExtension}_{DateTime.UtcNow.ToString("yyyy_MM_dd_HH_mm_ss_ffff")}{fileExtension}";
            var filePath = Path.Combine(targetFolderPath, uniqueFileName);



            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                try
                {
                    File.WriteAllBytes(filePath, memoryStream.ToArray());
                }
                catch (Exception ex)
                {

                    throw;
                }

            }

            return "/" + Path.Combine(folderPath, uniqueFileName).Replace("\\", "/");



        }
    }
}
