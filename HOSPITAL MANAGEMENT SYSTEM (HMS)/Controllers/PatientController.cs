using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.PatientDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork<Patient> _context;
        private readonly ICustomRepo<Patient> _custom;
        private readonly IMapper _mapper;
        public PatientController(IUnitOfWork<Patient> context, ICustomRepo<Patient> custom, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _custom = custom;
        }
        // GET: api/<PatientController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var entitymodel = _context.Patients.GetAll();
            var entitydto = _mapper.Map<List<PartiallyUpdatePatientDTO>>(entitymodel);
            return Ok(entitydto);
        }
        // GET: api/<PatientController>
        [HttpGet("History/{id}")]
        public IActionResult GetHistory(int id)
        {
            var entitymodel = _custom.PatientHistory();
            return Ok(entitymodel);
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entitymodel = _context.Patients.GetById(id);
            var entitydto = _mapper.Map<PartiallyUpdatePatientDTO>(entitymodel);
            return Ok(entitydto);
        }

        // POST api/<PatientController>
        [HttpPost]
        public IActionResult Create(CreateUpdatePatientDTO entitydto)
        {
            if (entitydto == null)
            {
                return BadRequest("Can't Create null");
            }
            var entitymodel = _mapper.Map<Patient>(entitydto);
            _context.Patients.Create(entitymodel);
            _context.Save();
            return CreatedAtAction(nameof(GetById), new { id = entitymodel.PatientId }, entitymodel);
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, PartiallyUpdatePatientDTO entitydto)
        {
            var entitymodel = _context.Patients.GetById(id);
            _mapper.Map(entitydto,entitymodel);
            _context.Patients.Update(entitymodel);
            _context.Save();
            return Ok();
        }

        // PATCH api/<PatientController>/5
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdate(int id, PartiallyUpdatePatientDTO entitydto)
        {
            var entitymodel = _context.Patients.GetById(id);
            if(entitydto.FullName != null)
            {
                entitymodel.FullName = entitydto.FullName;
            }
            if(entitydto.Gender != null)
            {
                entitymodel.Gender = entitydto.Gender;
            }
            if(entitydto.Address != null)
            {
                entitymodel.Address = entitydto.Address;
            }
            if(entitydto.Phone != null)
            {
                entitymodel.Phone = entitydto.Phone;
            }
            if(entitydto.DateOfBirth.HasValue)
            {
                entitymodel.DateOfBirth = entitydto.DateOfBirth.Value;
            }
            _context.Patients.Update(entitymodel);
            _context.Save();
            return Ok();
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _context.Patients.Delete(id);
            _context.Save();
            return Ok();
        }
    }
}
