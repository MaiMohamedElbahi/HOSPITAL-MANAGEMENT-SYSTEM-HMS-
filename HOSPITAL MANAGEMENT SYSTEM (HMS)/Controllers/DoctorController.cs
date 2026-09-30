using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DoctorDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IUnitOfWork<Doctor> _context;
        private readonly ICustomRepo<Doctor> _custom;
        private readonly IMapper _mapper;
        public DoctorController(IUnitOfWork<Doctor> context, ICustomRepo<Doctor> custom, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _custom = custom;
        }
        // GET: api/<DoctorController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var entitymodel = _context.Doctors.GetAll();
            var entitydto = _mapper.Map<List<PartiallyUpdateDoctorDTO>>(entitymodel);
            return Ok(entitydto);
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entitymodel = _context.Doctors.GetById(id);
            var entitydto = _mapper.Map<PartiallyUpdateDoctorDTO>(entitymodel);
            return Ok(entitydto);
        }

        // GET api/<DoctorController>/5
        [HttpGet("specialization/{spec}")]
        public IActionResult GetBySpecialization(string spec)
        {
            var entitymodel = _context.Doctors.GetAll();
            var entitymod = entitymodel.Where(x => x.Specialization == spec).ToList();
            return Ok(entitymod);
        }

        // GET api/<DoctorController>/5
        [HttpGet("Details")]
        public IActionResult GetDetails()
        {
            var doc = _custom.DoctorsDetais();
            
            return Ok(doc);
        }

        // POST api/<DoctorController>
        [HttpPost]
        public IActionResult Create(CreateUpdateDoctorDTO entitydto)
        {
            if (entitydto == null)
            {
                return BadRequest("Can't Create null");
            }
            var entitymodel = _mapper.Map<Doctor>(entitydto);
            _context.Doctors.Create(entitymodel);
            _context.Save();
            return CreatedAtAction(nameof(GetById), new { id = entitymodel.DoctorId }, entitymodel);
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, PartiallyUpdateDoctorDTO entitydto)
        {
            var entitymodel = _context.Doctors.GetById(id);
            _mapper.Map(entitydto,entitymodel);
            _context.Doctors.Update(entitymodel);
            _context.Save();
            return Ok();
        }

        // PATCH api/<DoctorController>/5
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdate(int id, PartiallyUpdateDoctorDTO entitydto)
        {
            var entitymodel = _context.Doctors.GetById(id);
            if(entitydto.FullName != null)
            {
                entitymodel.FullName = entitydto.FullName;
            }
            if(entitydto.Specialization != null)
            {
                entitymodel.Specialization = entitydto.Specialization;
            }
            if(entitydto.Email != null)
            {
                entitymodel.Email = entitydto.Email;
            }
            if(entitydto.Phone != null)
            {
                entitymodel.Phone = entitydto.Phone;
            }
            if(entitydto.Salary.HasValue)
            {
                entitymodel.Salary = entitydto.Salary.Value;
            }
            if(entitydto.DepartmentId.HasValue)
            {
                entitymodel.DepartmentId = entitydto.DepartmentId.Value;
            }
            _context.Doctors.Update(entitymodel);
            _context.Save();
            return Ok();
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _context.Doctors.Delete(id);
            _context.Save();
            return Ok();
        }
    }
}
