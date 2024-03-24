using Aplicacao.Produtos.Profiles;
using Aplicacao.Produtos.Servicos;
using Dominio.Produtos.Servicos;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Infra.Produtos;
using Infra.Produtos.Mapeamentos;
using NHibernate;
using ISession = NHibernate.ISession;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ProdutosProfile));

builder.Services.AddSingleton<ISessionFactory>(factory =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySql");
    return Fluently.Configure()
    .Database((MySQLConfiguration.Standard.ConnectionString(connectionString)
    .FormatSql()
    .ShowSql()))
    .Mappings(x =>
    {
        x.FluentMappings.AddFromAssemblyOf<ProdutosMap>();
    }).BuildSessionFactory();
});

builder.Services.AddSingleton<ISession>(factory => factory.GetService<ISessionFactory>()!.OpenSession());

builder.Services.Scan(scan =>
    scan.FromAssemblyOf<ProdutosAppServico>()
    .AddClasses()
    .AsImplementedInterfaces()
    .WithSingletonLifetime()

    .FromAssemblyOf<ProdutosServico>()
    .AddClasses()
    .AsImplementedInterfaces()
    .WithSingletonLifetime()

    .FromAssemblyOf<ProdutosRepositorio>()
    .AddClasses()
    .AsImplementedInterfaces()
    .WithSingletonLifetime());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    
    app.UseSwaggerUI();

    app.UseCors(c=>{
        c.AllowAnyHeader();
        c.AllowAnyMethod();
        c.AllowAnyOrigin();
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
