using Microsoft.EntityFrameworkCore;
using PremierLeague.BusinessLayer.Abstract;
using PremierLeague.BusinessLayer.Concrete;
using PremierLeague.BusinessLayer.Mapping;
using PremierLeague.DataAccessLayer.Abstract;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IFootballMatchDal, EfFootballMatchDal>();
builder.Services.AddScoped<IFootballMatchService, FootballMatchManager>();

builder.Services.AddScoped<IMatchEventDal, EfMatchEventDal>();
builder.Services.AddScoped<IMatchEventService, MatchEventManager>();

builder.Services.AddScoped<IMatchStatisticsDal, EfMatchStatisticDal>();
builder.Services.AddScoped<IMatchStatisticService, MatchStatisticManager>();

builder.Services.AddScoped<ISeasonDal, EfSeasonDal>();
builder.Services.AddScoped<ISeasonService, SeasonManager>();

builder.Services.AddScoped<ITeamDal, EfTeamDal>();
builder.Services.AddScoped<ITeamService, TeamManager>();

builder.Services.AddScoped<IWeekDal, EfWeekDal>();
builder.Services.AddScoped<IWeekService, WeekManager>();

builder.Services.AddScoped<IStandingsDal, EfStandingsDal>();
builder.Services.AddScoped<IStandingsService, StandingsManager>();

builder.Services.AddAutoMapper(typeof(GeneralMapping).Assembly);

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
