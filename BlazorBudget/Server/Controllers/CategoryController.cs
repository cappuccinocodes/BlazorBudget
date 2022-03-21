using BlazorBudget.Server.Repositories;
using BlazorBudget.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBudget.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<List<Category>> Get()
        {
            return await Task.FromResult(_categoryRepository.GetCategoryDetails());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Category user = _categoryRepository.GetCategoryData(id);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Post(Category category)
        {
            var categories = _categoryRepository.GetCategoryDetails().ToList();

            if (categories.Any(x => x.Name == category.Name))
            {
                ModelState.AddModelError(nameof(category.Name), "This category already exists");
                return BadRequest(ModelState);
            }
            else
            {
                _categoryRepository.AddCategory(category);
                return Ok(ModelState);
            }
        }

        [HttpPut]
        public void Put(Category category)
        {
            _categoryRepository.UpdateCategoryDetails(category);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return Ok();
        }
    }
}
