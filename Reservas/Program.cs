using Capitulo4.Repository;
using Microsoft.EntityFrameworkCore;
using Reservas.AutoMappers;
using Reservas.DTOs;
using Reservas.Models;
using Reservas.Repository;
using Reservas.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICommonService<RoomDto, RoomInsertDto, RoomUpdateDto>, RoomService>();
builder.Services.AddScoped<ICommonService<UserDto, UserInsertDto, UserUpdateDto>, UserService>();
builder.Services.AddScoped<ICommonService<ReserveDto, ReserveInsertDto, ReserveUpdateDto>, ReserveService>();


// Repository
builder.Services.AddScoped<IRepository<Room>, RoomRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Reserve>, ReserveRepository>();

// Entity Framework
builder.Services.AddDbContext<ReserveContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("ReserveConnection"), new MySqlServerVersion(new Version(9, 2, 0)));
});

//Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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