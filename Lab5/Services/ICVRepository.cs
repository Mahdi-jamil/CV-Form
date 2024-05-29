using Lab5.Models;
namespace Lab5.Services
{
    public interface ICVRepository 
    {
        public Task<int> AddCv(CVBindingModel bindingModel);
        public Task<CV> GetById(int Id);
        public List<CV> GetCVs();
    }
}
