﻿
//using BookStoreServer.WebApi.Context;
//using BookStoreServer.WebApi.Dtos;
//using BookStoreServer.WebApi.Models;
using Azure.Core;
using GSF.FuzzyStrings;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {

        
        var categories = SeedData.Categories;
        return Ok(SeedData.Categories);

    }
}


