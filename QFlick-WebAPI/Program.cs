using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using QFlick.Application.Extentions;
using QFlick.Infrastructure;
using QFlick_WebAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

//Add Application Dependencies
builder.Services.AddApplicationServicesExtentions();

builder.Services.AddHttpContextAccessor();

//Add Infrastructure Dependencies
builder.Services.AddInfrastructureDependencyInjection(builder.Configuration);

builder.Services.AddHttpContextAccessor();


//register cors to the applications
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
        policy.WithOrigins("http://localhost:14764").AllowAnyMethod().AllowAnyHeader();
    });
});


//Add WebAPI dependencies
//builder.Services.AddWebAPIServiceExtentions(builder.Configuration);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // Get Firebase configuration values from appsettings.json
        var validIssuer = builder.Configuration["JWTSettings:ValidIssuer"];
        var validAudience = builder.Configuration["JWTSettings:ValidAudience"];

        options.Authority = validIssuer; // Endpoint to retrieve token validation keys

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = validIssuer,

            ValidateAudience = true,
            ValidAudience = validAudience,

            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();


//register the fluent validatiors
//builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly, includeInternalTypes: true);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
