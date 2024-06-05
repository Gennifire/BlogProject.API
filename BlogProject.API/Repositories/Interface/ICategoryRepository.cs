using BlogProject.API.Models.Domain;

namespace BlogProject.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        //define methods only here
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>> GetAllAsync();

        //nullable category = ?
        Task<Category?> GetByIdAsync(Guid id);

        Task<Category> UpdateAsync(Category category);
    }
}
