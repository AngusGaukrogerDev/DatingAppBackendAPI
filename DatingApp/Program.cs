using DatingApp.Data;
using DatingApp.Logic.Filters.FilterUsersByGenderCommand;
using DatingApp.Logic.Filters.FilterUsersByLocationCommand;
using DatingApp.Logic.Filters.FilterUsersByMatchingInterestsCommand;
using DatingApp.Logic.MatchFeed.GetNextUserInFeedCommand;
using DatingApp.Logic.Users.CreateUserCommand;
using DatingApp.Logic.Users.DeleteUserCommand;
using DatingApp.Logic.Users.UpdateUserDetailsCommand;
using DatingApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection

//Models

builder.Services.AddScoped<IStandardApplicationUser, StandardApplicationUser>();

//Logic

builder.Services.AddScoped<ICreateUserCommand, CreateUserCommand>();
builder.Services.AddScoped<IDeleteUserCommand, DeleteUserCommand>();
builder.Services.AddScoped<IUpdateUserCommand, UpdateUserCommand>();

builder.Services.AddScoped<IGetNextUserInFeedCommand, GetNextUserInFeedCommand>();

builder.Services.AddScoped<IFilterUsersByMatchingInterestsCommand, FilterUsersByMatchingInterestsCommand>();
builder.Services.AddScoped<IFilterUsersByLocationCommand, FilterUsersByLocationCommand>();
builder.Services.AddScoped<IFilterUsersByGenderCommand, FilterUsersByGenderCommand>();

//Data

builder.Services.AddScoped<IAppDbContext, AppDbContext>();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
