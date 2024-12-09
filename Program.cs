using ENTITY_FRAMEWORK_EXAMPLE.Automappers;
using ENTITY_FRAMEWORK_EXAMPLE.DTOs;
using ENTITY_FRAMEWORK_EXAMPLE.Models;
using ENTITY_FRAMEWORK_EXAMPLE.Repository;
using ENTITY_FRAMEWORK_EXAMPLE.Services;
using ENTITY_FRAMEWORK_EXAMPLE.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injection string conection in dbcontext entity framework
builder.Services.AddDbContext<StoreContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});

//Repository
builder.Services.AddScoped<IRepository<Beer>, BeerRepository>();
builder.Services.AddScoped<IRepository<Brand>, BrandRepository>();

//Services
builder.Services.AddScoped<ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>, BeerService>();
builder.Services.AddScoped<ICommonService<BrandDto, BrandInsertDto, BrandUpdateDto>, BrandService>();

//Validators
builder.Services.AddScoped<IValidator<BeerInsertDto>, BeerInsertValidator>();
builder.Services.AddScoped<IValidator<BeerUpdateDto>, BeerUpdateValidator>();
builder.Services.AddScoped<IValidator<BrandInsertDto>, BrandInsertValidator>();
builder.Services.AddScoped<IValidator<BrandUpdateDto>, BrandUpdateValidator>();

//Mappers
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
