using Microsoft.AspNetCore.Mvc;
using TaskPlannerApi.Dtos;
using TaskPlannerApi.Extensions;
using TaskPlannerApi.Models;
using TaskPlannerApi.Repositories;

namespace TaskPlannerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoriesController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAll();

            if (categories == null || !categories.Any())
            {
                return NotFound();
            }
            var categoryDtos = categories.ConvertToDTO();
            return Ok(categoryDtos);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(CategoryDTO categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid category item data");
            }

            var existingCategory = await _categoryRepository.Get(categoryDto.Id);

            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = categoryDto.Name;
            var updatedCategory = await _categoryRepository.Update(existingCategory);
            return Ok(updatedCategory);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var deleted = await _categoryRepository.Delete(id);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCategory(CategoryDTO categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid category item data");
            }
            var category = new Category
            {
                Name = categoryDto.Name
            };

            var createdCategory = await _categoryRepository.Create(category);
            var createdCategoryDto = createdCategory.ConvertToDTO();

            return Ok(createdCategoryDto);
        }
    }
}
