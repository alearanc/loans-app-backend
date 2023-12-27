using API.DataAccess;
using API.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("LoanAppDB")));

builder.Services.AddControllers();

var app = builder.Build();


//  PRUEBA INICIAL - FUNCIONA
//using var context = new AppDbContext();

//await Create(context);
//await ReadAll(context);

//static async Task<int> Create(AppDbContext context)
//{
//    var category = new Category()
//    {
//        Description = "libros",
//        CreationDate = new DateOnly(1997, 01, 22)
//    };
//    category.Things.Add(new Thing()
//    {
//        Description = "1984",
//        CreationDate = new DateOnly(2022, 01, 22)
//    });
//    category.Things.Add(new Thing()
//    {
//        Description = "Un mundo feliz",
//        CreationDate = new DateOnly(2022, 01, 22)
//    });

//    context.Add(category);
//    await context.SaveChangesAsync();

//    return category.Id;
//}

//static async Task ReadAll(AppDbContext context)
//{
//    var categories = await context.Categories.ToListAsync();
//    var options = new JsonSerializerOptions()
//    {
//        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
//        //ReferenceHandler = ReferenceHandler.Preserve,
//        WriteIndented = true,
//    };

//    categories.ForEach(c =>
//    {
//        string json = JsonSerializer.Serialize(c, options);
//        Console.WriteLine(json);
//    });
//}

app.MapControllers();

app.Run();
