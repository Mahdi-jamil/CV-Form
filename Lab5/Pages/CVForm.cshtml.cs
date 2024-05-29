using Lab5.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Lab5.Services;

namespace Lab5.Pages
{
    public class CVFormModel : PageModel
    {
        private readonly CvRepository cvRepository;
        public CVFormModel( CvRepository repository )
        {
            cvRepository = repository;
        }

        [BindProperty]
        public CVBindingModel CVBinding { get; set; }
        public CVViewModel ViewModel { get; set; }

        public List<SelectListItem> Nationalities { get; set; } = new List<SelectListItem>
            {
                new SelectListItem { Value = "US", Text = "United States" },
                new SelectListItem { Value = "UK", Text = "United Kingdom" },
                new SelectListItem { Value = "CA", Text = "Canada" },
                new SelectListItem { Value = "AU", Text = "Australia" }
            };

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostInfo(int random)
        {
            if (CVBinding.num1 + CVBinding.num2 != CVBinding.sum )
            {
                ModelState.AddModelError("Validation", "Sum of number 1 and number 2 should be equal to sum");
                Console.WriteLine(string.Join(",", ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage)));
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            int id = await cvRepository.AddCv(CVBinding);
            return RedirectToPage("/CVDisplay", new { random, id }  );
        }
    }
}
