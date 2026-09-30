using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Data;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Mappings;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Implementations;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    "Data Source=(localdb)\\MaiLocalDb;Initial Catalog = HospitalManagementSystems;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True"));
builder.Services.AddScoped(typeof(IUnitOfWork<>),typeof(UnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepo<>),typeof(GenericRepo<>));
builder.Services.AddScoped(typeof(ICustomRepo<>),typeof(CustomRepo<>));
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
