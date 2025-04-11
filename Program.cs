using EntitiesTest;
using EntitiesTest.Application.Interfaces.Repositories;
using EntitiesTest.Infrastructure.Repositories;
using EntitiesTest.Application.Services;
using EntitiesTest.Application.Services.Interfaces;


using Microsoft.EntityFrameworkCore;
using EntitiesTest.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBidRepository, BidRepository>();
builder.Services.AddScoped<ITenderRepository, TenderRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBidService, BidService>();
builder.Services.AddScoped<ITenderService, TenderService>();
builder.Services.AddScoped<IBidDocumentRepository, BidDocumentRepository>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<IEvaluationRepository, EvaluationRepository>();   
builder.Services.AddScoped<IEvaluationService, EvaluationService>();


// 🔹 Configure EF Core (update with your connection string)
builder.Services.AddDbContext<TendersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Add custom services, repositories, etc. (example)
// builder.Services.AddScoped<IUserService, UserService>();

// 🔹 CORS (optional, useful for frontend integration later)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// 🔹 Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll"); // Enable CORS

app.UseAuthorization();

app.MapControllers();

app.Run();