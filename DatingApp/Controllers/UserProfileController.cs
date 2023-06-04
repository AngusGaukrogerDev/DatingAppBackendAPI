using Microsoft.AspNetCore.Mvc;
using Minio;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly MinioClient _minioClient;
        public UserProfileController()
        {
            _minioClient = new MinioClient();
        }

        [HttpPost("/api/UserProfileController/Photos/UploadPhoto")]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file selected");
            }
            string objectName = Path.GetRandomFileName();

            try
            {
                // Create a MemoryStream to read the uploaded file
                using (var memoryStream = new MemoryStream())
                {
                    // Copy the uploaded file to the MemoryStream
                    await file.CopyToAsync(memoryStream);

                    // Set the position to the beginning of the stream
                    memoryStream.Position = 0;

                    // Call the external method to handle the file upload to Minio
                    await UploadToMinio(objectName, memoryStream);
                }

                return Ok("File uploaded successfully");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the upload
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
