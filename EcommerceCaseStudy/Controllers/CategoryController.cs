using AutoMapper;
using EcommerceCaseStudy.DTO.Category;
using EcommerceCaseStudy.Models;
using EcommerceCaseStudy.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var c = await _unit.Category.GetAll();
            var dto=_mapper.Map<List<GetCategoryDTO>>(c);
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Add(CreateCategoryDTO dto)
        {
            if (dto == null || !ModelState.IsValid) { return BadRequest(); }

            var cat=_mapper.Map<Category>(dto);

            _unit.Category.Add(cat);
            _unit.Save();
            return Created();
        }
    }
}
