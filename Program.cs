using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using BookStore.BookStore.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.AddDbContext<BookStoreDbContext>(options => 
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(BookStoreDbContext)));    
} );

builder.Services.ConfigureHttpJsonOptions(options =>
{
    object AppJsonSerializerContext = null;
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

app.Run();

