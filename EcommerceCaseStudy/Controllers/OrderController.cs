using AutoMapper;
using EcommerceCaseStudy.DTO.Category;
using EcommerceCaseStudy.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        public OrderController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var c = await _unit.Order.GetAll();
           // var dto = _mapper.Map<List<GetCategoryDTO>>(c);
            return Ok(c);
        }


        
    }
}
