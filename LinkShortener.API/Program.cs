
using LinkShortener.API.Infrastructure;
using LinkShortener.API.Features.Links;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<InMemoryLinkStore>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Vertical Slice Endpoints
app.MapCreateLinkEndpoint();
app.MapRedirectLinkEndpoint();

app.Run();
