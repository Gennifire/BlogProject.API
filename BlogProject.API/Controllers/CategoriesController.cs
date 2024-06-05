using Azure.Core;
using BlogProject.API.Data;
using BlogProject.API.Models.Domain;
using BlogProject.API.Models.DTO;
using BlogProject.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        //CRUD: C - Create
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDTO request)
        {
            //map DTO to domain model
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await _categoryRepository.CreateAsync(category);

            //Domain model to DTO
            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }

        //CRUD: R - Read = GET: 'https://localhost:7041/api/Categories'
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var allCategories = await _categoryRepository.GetAllAsync();
            //map domain model to DTO

            var response = new List<CategoryDTO>();
            foreach (var category in allCategories)
            {
                response.Add(new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                });
            }

            return Ok(response);
        }

        //CRUD: R - READ (single) GET BY ID: 'https://localhost:7041/api/Categories/{id}'
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var exisitingCategory = await _categoryRepository.GetByIdAsync(id);

            if (exisitingCategory == null)
            {
                return NotFound();
            }

            var response = new CategoryDTO
            {
                Id = exisitingCategory.Id,
                Name = exisitingCategory.Name,
                UrlHandle = exisitingCategory.UrlHandle
            };

            return Ok(response);
        }

        //CRUD: U - Update = PUT: 'https://localhost:7041/api/Categories/{id}'
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditCategory([FromRoute] Guid id, UpdateCategoryRequestDTO requst)
        {
            //convert DTO to domain
            var category = new Category
            {
                Id = id,
                Name = requst.Name,
                UrlHandle = requst.UrlHandle
            };

            category = await _categoryRepository.UpdateAsync(category);

            if (category == null)
            {
                return NotFound();
            }

            //convert domain to DTO
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
