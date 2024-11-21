using Lab6;
using Lab6.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


ConfigUpload.Load(builder.Configuration);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var googlePublicKeysUrl = "https://www.googleapis.com/oauth2/v3/certs";

        options.Authority = "https://accounts.google.com";
        options.Audience = ConfigUpload.ClientId;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://accounts.google.com",
            ValidateAudience = true,
            ValidAudience = ConfigUpload.ClientId,
            ValidateLifetime = true,
            IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
            {
                var keys = GoogleOpenIdService.GetPublicKeysFromGoogle(googlePublicKeysUrl).Result;
                return keys.Where(k => k.KeyId == kid);
            }
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiUser", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("email");
    });
});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var dbType = builder.Configuration["DbType"] ?? "SQLITE";

    switch (dbType.ToUpper())
    {
        case "MSSQL":
            options.UseSqlServer(connectionString);
            break;
        case "POSTGRES":
            options.UseNpgsql(connectionString);
            break;
        case "SQLITE":
            options.UseSqlite(connectionString);
            break;
        case "INMEMORY":
            options.UseInMemoryDatabase("InMemoryDb");
            break;
        default:
            throw new InvalidOperationException("Unsupported DB type");
    }
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

app.MapControllers();

app.Run();
