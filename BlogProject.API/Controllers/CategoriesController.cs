using BlogProject.API.Data;
using BlogProject.API.Models.Domain;
using BlogProject.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbcontext _dbContext;

        public CategoriesController(ApplicationDbcontext dbContext)
        {
            this._dbContext = dbContext;
        }
        //
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDTO request)
        {
            //map DTO to domain model
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await _dbContext.Catergories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            //Domain model to DTO
            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }
    }
}
