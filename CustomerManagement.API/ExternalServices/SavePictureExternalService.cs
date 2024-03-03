namespace CustomerManagement.API.ExternalServices
{
    public class SavePictureExternalService
    {
        private readonly IWebHostEnvironment _environment;
        public SavePictureExternalService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<string> AddPictureAndGetPath(IFormFile file)
        {
            string path = Path.Combine(_environment.WebRootPath, "images", Guid.NewGuid() + file.FileName);
            using(var stream = File.Create(path))
            {
                await file.CopyToAsync(stream);
            }
            return path;
        }

    }
}
