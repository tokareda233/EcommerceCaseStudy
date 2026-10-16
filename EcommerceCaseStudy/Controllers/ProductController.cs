using AutoMapper;
using EcommerceCaseStudy.DTO.Category;
using EcommerceCaseStudy.DTO.Product;
using EcommerceCaseStudy.Models;
using EcommerceCaseStudy.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var c = await _unit.Product.GetAll();
            var dto = _mapper.Map<List<GetProductDTO>>(c);
            return Ok(dto);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var c = await _unit.Product.SearchByName(name);
            var dto = _mapper.Map<List<GetProductDTO>>(c);
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Add(CreateProductDTO dto)
        {
            if (dto == null || !ModelState.IsValid) { return BadRequest(); }

            var cat = _mapper.Map<Product>(dto);

            _unit.Product.Add(cat);
            _unit.Save();
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var c = await _unit.Product.GetById(id);
            var dto = _mapper.Map<GetProductDTO>(c);
            return Ok(dto);
        }


        [HttpPut]
        public async Task<IActionResult> Update(int id, CreateProductDTO dto)
        {
            if (dto == null || !ModelState.IsValid) { return BadRequest(); }

            var p = await _unit.Product.GetById(id);
            if(p== null) {  return BadRequest(); }

            _mapper.Map(dto, p);
            _unit.Product.Update(p);
            _unit.Save();

            return Ok(dto);

        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id , int stockquantity)
        {
            var p = await _unit.Product.GetById(id);
            if (p == null) { return BadRequest(); }

            p.StockQuantity = stockquantity;
            _unit.Product.Update(p) ;
            _unit.Save();
            return NoContent();

        }

        [HttpGet("pagnation")]
        public async Task<IActionResult> Pagnation(int? categoryid, string? sortby, int pagenumber = 1, int pagesize = 5)
        {
            var c = await _unit.Product.Pagnation(categoryid, sortby, pagenumber, pagesize);
            if (c == null) { return BadRequest(); }

            var dto = _mapper.Map<List<GetProductDTO>>(c);
            return Ok(dto);
        }

        [HttpGet("second-most-expensive-Product-excluding-category")]
        public async Task<IActionResult> SecondExpensive(int categoryid)
        {
            var c=await _unit.Product.SecondMostExpensiveProductExcludingCategory(categoryid);
            if (c == null) { return  NotFound(); }
            var dto = _mapper.Map<GetProductDTO>(c);
            return Ok(dto);
        }


    }
}
