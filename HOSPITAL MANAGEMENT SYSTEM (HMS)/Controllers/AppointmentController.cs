using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.AppointmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IUnitOfWork<Appointment> _context;
        private readonly IMapper _mapper;
        public AppointmentController(IUnitOfWork<Appointment> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<AppointmentController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var entitymodel = _context.Appointments.GetAll();
            var entitydto = _mapper.Map<List<PartiallyUpdateAppointmentDTO>>(entitymodel);
            return Ok(entitydto);
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entitymodel = _context.Appointments.GetById(id);
            var entitydto = _mapper.Map<PartiallyUpdateAppointmentDTO>(entitymodel);
            return Ok(entitydto);
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public IActionResult Create(CreateUpdateAppointmentDTO entitydto)
        {
            if (entitydto == null)
            {
                return BadRequest("Can't Create null");
            }
            var entitymodel = _mapper.Map<Appointment>(entitydto);
            _context.Appointments.Create(entitymodel);
            _context.Save();
            return CreatedAtAction(nameof(GetById), new { id = entitymodel.AppointmentId }, entitymodel);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateUpdateAppointmentDTO entitydto)
        {
            var entitymodel = _context.Appointments.GetById(id);
            _mapper.Map(entitydto,entitymodel);
            _context.Appointments.Update(entitymodel);
            _context.Save();
            return Ok();
        }

        // PATCH api/<AppointmentController>/5
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdate(int id, PartiallyUpdateAppointmentDTO entitydto)
        {
            var entitymodel = _context.Appointments.GetById(id);
            if (entitydto.DoctorId.HasValue)
            {
                entitymodel.DoctorId = entitydto.DoctorId.Value;
            }
            if (entitydto.PatientId.HasValue)
            {
                entitymodel.PatientId = entitydto.PatientId.Value;
            }
            if (entitydto.MedicalRecordId.HasValue)
            {
                entitymodel.MedicalRecordId = entitydto.MedicalRecordId.Value;
            }
            if (entitydto.AppointmentDate.HasValue)
            {
                entitymodel.AppointmentDate = entitydto.AppointmentDate.Value;
            }
            _context.Appointments.Update(entitymodel);
            _context.Save();
            return Ok();
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _context.Appointments.Delete(id);
            _context.Save();
            return Ok();
        }
    }
}
