﻿using BlogProject.API.Data;
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
            await _dbContext.Catergories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return category;
        }
    }
}