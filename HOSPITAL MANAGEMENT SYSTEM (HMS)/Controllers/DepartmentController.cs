using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DepartmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork<Department> _context;
        private readonly IMapper _mapper;
        public DepartmentController(IUnitOfWork<Department> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var entitymodel = _context.Departments.GetAll();
            var entitydto = _mapper.Map<List<PartiallyUpdateDepartmentDTO>>(entitymodel);
            return Ok(entitydto);
        }
        // GET: api/<DepartmentController>
        [HttpGet("doctor-count")]
        public IActionResult GetDoctorCount()
        {
            var entitymodel = _context.Departments.GetAll();
            return Ok(entitymodel.Count());
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entitymodel = _context.Departments.GetById(id);
            var entitydto = _mapper.Map<PartiallyUpdateDepartmentDTO>(entitymodel);
            return Ok(entitydto);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public IActionResult Create(CreateUpdateDepartmentDTO entitydto)
        {
            if (entitydto == null)
            {
                return BadRequest("Can't Create null");
            }
            var entitymodel = _mapper.Map<Department>(entitydto);
            _context.Departments.Create(entitymodel);
            _context.Save();
            return CreatedAtAction(nameof(GetById), new { id = entitymodel.DepartmentId }, entitymodel);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, PartiallyUpdateDepartmentDTO entitydto)
        {
            var entitymodel = _context.Departments.GetById(id);
            _mapper.Map(entitydto,entitymodel);
            _context.Departments.Update(entitymodel);
            _context.Save();
            return Ok();
        }

        // PATCH api/<DepartmentController>/5
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdate(int id, PartiallyUpdateDepartmentDTO entitydto)
        {
            var entitymodel = _context.Departments.GetById(id);
            if(entitydto.Name != null)
            {
                entitymodel.Name = entitydto.Name;
            }
            if(entitydto.Location != null)
            {
                entitymodel.Name = entitydto.Location;
            }
            _context.Departments.Update(entitymodel);
            _context.Save();
            return Ok();
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _context.Departments.Delete(id);
            _context.Save();
            return Ok();
        }
    }
}
