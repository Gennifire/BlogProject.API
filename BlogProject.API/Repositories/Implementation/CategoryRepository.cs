using BlogProject.API.Data;
using BlogProject.API.Models.Domain;
using BlogProject.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbcontext _dbContext;
        public CategoryRepository(ApplicationDbcontext applicationDbcontext)
        {
            this._dbContext = applicationDbcontext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }


        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(category => category.Id == id);
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if (existingCategory != null)
            {
                _dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await _dbContext.SaveChangesAsync();
                return category;
            }

            return null;
        }
    }
}
