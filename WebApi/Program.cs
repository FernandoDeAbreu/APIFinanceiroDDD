using Domain.Interfaces.Generics;
using Domain.Interfaces.ICategoria;
using Domain.Interfaces.IDespesa;
using Domain.Interfaces.ISistemaFinanceiro;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Domain.Interfaces.Services;
using Domain.Services;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Infra.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();

builder.Services.AddSingleton(typeof(IGeneric<>), typeof(GenericRepository<>));
builder.Services.AddSingleton<ICategoria, CategoriaRepository>();
builder.Services.AddSingleton<IDespesa, DespesaRepository>();
builder.Services.AddSingleton<ISistemaFinanceiro, SistemaFinanceiroRepository>();
builder.Services.AddSingleton<IUsuarioSistemaFinanceiro, UsuarioSistemaFinanceiroRepository>();

builder.Services.AddSingleton<ICategoriaServices, CategoriaServices>();
builder.Services.AddSingleton<IDespesaServices, DespesaServices>();
builder.Services.AddSingleton<ISistemaFinanceiroServices, SistemaFinanceiroServices>();
builder.Services.AddSingleton<IUsuarioSistemaFinanceiroServices, UsuarioSistemaFinanceiroServices>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(option =>
             {
                 option.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,

                     ValidIssuer = "Teste.Securiry.Bearer",
                     ValidAudience = "Teste.Securiry.Bearer",
                     IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
                 };

                 option.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                         return Task.CompletedTask;
                     },
                     OnTokenValidated = context =>
                     {
                         Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                         return Task.CompletedTask;
                     }
                 };
             });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var devClient = "http://localhost:4200";
app.UseCors(x =>
x.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.WithOrigins(devClient)); 

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();