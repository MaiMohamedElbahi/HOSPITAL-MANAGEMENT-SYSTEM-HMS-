using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.MedicalRecordDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IUnitOfWork<MedicalRecord> _context;
        private readonly IMapper _mapper;
        public MedicalRecordController(IUnitOfWork<MedicalRecord> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<MedicalRecordController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var entitymodel = _context.MedicalRecords.GetAll();
            var entitydto = _mapper.Map<List<PartiallyUpdateMedicalRecordDTO>>(entitymodel);
            return Ok(entitydto);
        }

        // GET api/<MedicalRecordController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entitymodel = _context.MedicalRecords.GetById(id);
            var entitydto = _mapper.Map<PartiallyUpdateMedicalRecordDTO>(entitymodel);
            return Ok(entitydto);
        }

        // POST api/<MedicalRecordController>
        [HttpPost]
        public IActionResult Create(CreateUpdateMedicalRecordDTO entitydto)
        {
            if (entitydto == null)
            {
                return BadRequest("Can't Create null");
            }
            var entitymodel = _mapper.Map<MedicalRecord>(entitydto);
            _context.MedicalRecords.Create(entitymodel);
            _context.Save();
            return CreatedAtAction(nameof(GetById), new { id = entitymodel.MedicalRecordId }, entitymodel);
        }

        // PUT api/<MedicalRecordController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, PartiallyUpdateMedicalRecordDTO entitydto)
        {
            var entitymodel = _context.MedicalRecords.GetById(id);
            _mapper.Map(entitydto,entitymodel);
            _context.MedicalRecords.Update(entitymodel);
            _context.Save();
            return Ok();
        }

        // PATCH api/<MedicalRecordController>/5
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdate(int id, PartiallyUpdateMedicalRecordDTO entitydto)
        {
            var entitymodel = _context.MedicalRecords.GetById(id);
            if(entitydto.Diagnosis != null)
            {
                entitymodel.Diagnosis = entitydto.Diagnosis;
            }
            if(entitydto.Prescription != null)
            {
                entitymodel.Prescription = entitydto.Prescription;
            }
            if(entitydto.Notes != null)
            {
                entitymodel.Notes = entitydto.Notes;
            }
            if(entitydto.AppointmentId.HasValue)
            {
                entitymodel.AppointmentId = entitydto.AppointmentId.Value;
            }
            _context.MedicalRecords.Update(entitymodel);
            _context.Save();
            return Ok();
        }

        // DELETE api/<MedicalRecordController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _context.MedicalRecords.Delete(id);
            _context.Save();
            return Ok();
        }
    }
}
