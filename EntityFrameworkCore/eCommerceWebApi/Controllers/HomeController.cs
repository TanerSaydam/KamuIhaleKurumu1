using eCommerceWebApi.Context;
using eCommerceWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetIndex()
        {
            //    List<Category> categories = new();
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Category category = new()
            //        {
            //            Name = "Kayıt " + i
            //        };
            //        categories.Add(category);
            //    }

            //    _context.AddRange(categories);
            //    _context.SaveChanges();


            var result5 = _context.Categories
                       .Select(s => new
                       {
                           Name = s.Name,
                           Total = 5 * 10,
                           IsActive = true
                       })
                       .AsEnumerable()  // Move query execution to client-side
                       .Select((s, index) => new
                       {
                           RowNumber = index + 1,
                           s.Name,
                           s.Total,
                           s.IsActive
                       })
                       .ToList();

            return Ok(result5);
        }

        [HttpGet]
        public async Task<IActionResult> Test(CancellationToken cancellationToken)
        {
            #region Create İşlemleri
                _context.Set<Category>().Add(new Category(){ Name = "Deneme"}); //insert into Category Values(@p1,@p2)
                _context.Add(new Category());
                _context.Add<Category>(new Category());
                _context.Categories.Add(new Category());
                List<Category> categories = new();
                _context.AddRange(categories);

                await _context.Set<Category>().AddAsync(new Category(), cancellationToken);
                await _context.Set<Category>().AddRangeAsync(categories, cancellationToken);
            #endregion

            #region Read İşlemleri
            _context.Categories.AsNoTracking().ToList();
            await _context.Categories.AsNoTracking().ToListAsync(cancellationToken);

            var result = _context.Categories.Where(p => p.Name.Contains("adasd")).AsQueryable();
            if("Parametre" == "Name")
            {
                result = result.OrderBy(p => p.Name).ThenBy(p=> p.Id);
            }
            else
            {
                result = result.OrderBy(p => p.Id).ThenBy(p => p.Name);
            }
            result.Where(p => p.Id != "adadw").ToList();

            var result1 = _context.Categories.Find("dzasd");
            var result2 = await _context.Categories.FindAsync("dzasd");

            var result3 = _context.Categories.Where(p => p.Id == "adwad" && p.Name == "adawd").FirstOrDefault();
            var result4 = 
                _context.Categories
                .Where(p => p.Id == "adwad" && p.Name == "adawd")
                .SingleOrDefault();

            var result5 = _context.Categories.Select((s,index) => new
            {
                Index = index,
                Name = s.Name,
                Total = 5 * 10,
                IsActive = true
            }).ToList();
            //select * from Categories where Name like '%adasd%' && Id != 'adadw'
            #endregion

            #region Update İşlemleri
            //Select Top 1 * from Categories Where Id=@Id
            Category? category = 
                    _context.Categories.Where(p => p.Id == "54646")
                    .FirstOrDefault();
                category.Name = "Deneme 2";

                //_context.Set<Category>().Update(category);
                //_context.Update(category);
                //_context.Update<Category>(category);

                List<Category> newCategories = _context.Categories.AsNoTracking().ToList();

                //değişiklik yapma
                _context.Categories.UpdateRange(newCategories);
            #endregion

            #region Delete İşlemleri
                Category removeCategory = _context.Categories.Find("ad");
                //Category removeCategory = new()
                //{
                //    Id = "46456"
                //};
                _context.Categories.Remove(removeCategory);
                _context.Remove(removeCategory);
                _context.RemoveRange(categories);
            #endregion

            _context.SaveChanges();
            await _context.SaveChangesAsync(cancellationToken);


            return NoContent();
        }
    }
}
