using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using TasteMuseum.Business.Abstract;
using TasteMuseum.Business.Concrete;
using TasteMuseum.DataAccess.Abstract;
using TasteMuseum.DataAccess.Concreate;
using TasteMuseum.DataAccess.EntityFramework;
using TasteMuseum.Entity.Concreate;
using TasteMuseum.Entity.Concrete;

var builder = WebApplication.CreateBuilder(args);

// DbContext Configuration
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity
builder.Services.AddIdentity<User, UserRole>(options =>
{
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+&#x27'\"";
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<Context>()
.AddDefaultTokenProviders();

// Add Authentication with Cookie
builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        options.LoginPath = "/Authentication/Login";
        options.LogoutPath = "/Authentication/Logout";
        options.AccessDeniedPath = "/Authentication/AccessDenied";
    });

// Add MVC and Authorization Policies
builder.Services.AddControllersWithViews(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

// Register your services
builder.Services.AddScoped<IRestaurantService, RestaurantManager>();
builder.Services.AddScoped<IRestaurantDal, EfRestaurantDal>();

builder.Services.AddScoped<IFoodService, FoodManager>();
builder.Services.AddScoped<IFoodDal, EfFoodDal>();

builder.Services.AddScoped<IRestaurantCommentService, RestaurantCommentManager>();
builder.Services.AddScoped<IRestaurantCommentDal, EfRestaurantCommentDal>();

builder.Services.AddScoped<IFoodCommentService, FoodCommentManager>();
builder.Services.AddScoped<IFoodCommentDal, EfFoodCommentDal>();

// Swagger Configuration
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

// Middleware Configuration
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Identity Middleware
app.UseAuthentication(); // Add authentication
app.UseAuthorization();  // Add authorization

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
