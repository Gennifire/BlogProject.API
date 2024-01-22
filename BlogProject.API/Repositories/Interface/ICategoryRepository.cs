﻿using BlogProject.API.Models.Domain;

namespace BlogProject.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        //define methods only here
        Task<Category> CreateAsync(Category category);
    }
}