var builder = WebApplication.CreateBuilder(args);

// Add services to the container. (Inject your services)


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//configure the HTTP pipeline or middleware

app.UseHttpsRedirection();

app.UseAuthorization();
/*
//context is a large object of request info from client
app.Use(async (context, next) => {

    if (context.Request.Method == "GET") {
        await next();
    }

}); */

/*
app.Map("/", (HttpContext context) => {
    context.Response.WriteAsync("Request handled by the next middleware");
}); */

app.MapControllers();
app.Run();
