using RealEstate.API.Hubs;
using RealEstate.API.Models.DapperContext;
using RealEstate.API.Repositories.CategoryRepository;
using RealEstate.API.Repositories.ContactRepository;
using RealEstate.API.Repositories.EmployeeRepository;
using RealEstate.API.Repositories.OfferRepository;
using RealEstate.API.Repositories.PopularLocationRepository;
using RealEstate.API.Repositories.ProductRepository;
using RealEstate.API.Repositories.ServiceRepository;
using RealEstate.API.Repositories.StatisticRepository;
using RealEstate.API.Repositories.TestimonialRepository;
using RealEstate.API.Repositories.ToDoListRepository;
using RealEstate.API.Repositories.WhoWeAreRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IWhoWeAreRepository, WhoWeAreRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IOfferRepository, OfferRepository>();
builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IStatisticRepository, StatisticRepository>();
builder.Services.AddTransient<IToDoListRepository, ToDoListRepository>();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
                          .AllowAnyMethod()
                          .SetIsOriginAllowed(origin => true) // Allow any origin
                          .AllowCredentials() // Allow credentials
                          .AllowAnyHeader());
});

builder.Services.AddHttpClient();
builder.Services.AddSignalR();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

app.Run();
