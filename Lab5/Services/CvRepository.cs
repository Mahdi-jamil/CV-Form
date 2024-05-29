using Lab5.Data;
using Lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Services
{
    public class CvRepository : ICVRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CvRepository(AppDbContext _db, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            dbContext = _db;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> AddCv(CVBindingModel bindingModel)
        {
            string url = await AddPhoto(bindingModel.Photo) ;
            var cv = new CV()
            {
                FName = bindingModel.FName,
                LName = bindingModel.LName,
                BDay = bindingModel.BDay,
                Sex = bindingModel.Sex,
                Email = bindingModel.Email,
                Nationality = bindingModel.Nationality,
                Password = bindingModel.Password,
                Skills = bindingModel.Skills,
                url = url
            };
            dbContext.CVs.Add(cv);
            dbContext.SaveChanges();
            return cv.Id;
        }

        public List<CV> GetCVs()
        {
            return dbContext.CVs.ToList();
        }

        public async Task<CV> GetById(int Id)
        {
            CV CV = await dbContext.CVs.FindAsync(Id);
            if(CV == null)
            {
                CV = new CV() { Id = -1, FName = "not found",LName = "not found",};
            }
            return CV;

        }



        private async Task<string> AddPhoto(IFormFile image)
        {
            var fileExtension = Path.GetExtension(image.FileName);
            // the addition of the guid is so that we don't have images with same name on the server
            // a guid is a globally unique identifier
            var guid = Guid.NewGuid();
            var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "images", $"{image.FileName + guid}{fileExtension}");
            // Upload Image to local path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.CopyToAsync(stream);

            // we want to access the image through something like this => http://localhost:1234/images/image.jpg
            // with the written code, http://localhost:1234 would be swapped with whatever domain the server is hosted on,
            // making it ready for production
            var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}" +
                              $"{_httpContextAccessor.HttpContext.Request.PathBase}/images/{image.FileName + guid}{fileExtension}";
            return urlFilePath;
        }


    }
}
