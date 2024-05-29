using Lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab5.Services;

namespace Lab5.Pages
{
    public class CVDisplayModel : PageModel
    {
        private readonly CvRepository repository;
        public CVDisplayModel(CvRepository cvRepository)
        {
            repository = cvRepository;
        }

        public ViewProperty CV { get; set; }
 
        int random {  get; set; }

        public async Task<IActionResult> OnGet(int Random,int Id)
        {
            CV CVResult = await repository.GetById(Id);
            this.random = Random;
            CV = new ViewProperty
            {
                Id = CVResult.Id,
                LName = CVResult.LName,
                FName = CVResult.FName,
                BDay = CVResult.BDay,
                Nationality = CVResult.Nationality,
                Sex = CVResult.Sex,
                Email = CVResult.Email,
                Skills = CVResult.Skills,
                ImageUrl = CVResult.url

            };
            return Page();
        }
    }
}
