using _01.MyFirstApi.Context;
using _01.MyFirstApi.Dtos;
using _01.MyFirstApi.Extensions;
using _01.MyFirstApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _01.MyFirstApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpPost()]
    public IActionResult GetAll(Request request)
    {
        AppDbContext context = new();
        //IQueryable<Product> producst = context.Set<Product>().AsQueryable()
            


        //if(request.ColumnName == "Name")
        //{
        //    if (request.Reverse)
        //    {
        //        producst = producst.OrderByDescending(p=> p.Name);
        //    }
        //    else
        //    {
        //        producst = producst.OrderBy(p => p.Name);
        //    }
        //}else if(request.ColumnName == "Price")
        //{
        //    if (request.Reverse)
        //    {
        //        producst = producst.OrderByDescending(p => p.Price);
        //    }
        //    else
        //    {
        //        producst = producst.OrderBy(p => p.Price);
        //    }
        //}

        PaginationResult<Product> paginationResult =
            context.Set<Product>()
            .Where(p=> p.Name.ToLower().Contains(request.Search) || p.Price.ToString()
            .Contains(request.Search))
            .RequestOrderBy(request.ColumnName, request.Reverse)
            .ToPagedList(request.PageNumber, request.PageSize);

        //IQueryable<Product> products = context.Set<Product>()
        //    .AsNoTracking()
        //    .AsQueryable();


        //List<Product> productLists =
        //    products            
        //    .Skip(request.PageSize * (request.PageNumber - 1))
        //    .Take(request.PageSize)
        //    .ToList();

        //int count = context.Set<Product>().Count();

        //PaginationResult<Product> paginationResult = new(
        //    datas: productLists,
        //    pageNumber: request.PageNumber,
        //    pageSize: request.PageSize,
        //    count: count);
        

        return Ok(paginationResult);
    }
}
