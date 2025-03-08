using Bogus;
using Catalogo.Domain.Categories;
using Catalogo.Domain.Products;
using Catalogo.Infrastructure;

namespace Catalogo.Api.Extensions;

public static class DataSeed
{
    public static async Task SeedCatalogoProductAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        try
        {
            var context = services.GetRequiredService<CatalogoDbContext>();
            var categoryRepository = services.GetRequiredService<ICategoryRepository>();

            if (context.Set<Category>().Any() is false)
            {
                var categories = new List<Category>
                {
                    Category.Create("Phones"),
                    Category.Create("Computers")
                };

                context.AddRange(categories);
                await context.SaveChangesAsync();
            }

            if (context.Set<Product>().Any() is false)
            {
                var categories = await categoryRepository.GetAllAsync();
                var computerCategory = categories.Single(c => c.Name == "Computers");
                var phoneCategory = categories.Single(c => c.Name == "Phones");

                var faker = new Faker();
                var hashids = new Hashids("custom_salt", 8);

                List<Product> products = [];
                for (int i = 0; i < 10; i++)
                {
                    var category = i > 5 ? computerCategory : phoneCategory;
                    var categoryPrefix = category.Name == "Computers" ? "CMP" : "PHN";
                    var productCode = $"{categoryPrefix}-{hashids.Encode(category.Id.GetHashCode(), i)}";

                    var product = Product.Create(
                        faker.Commerce.ProductName(),
                        faker.Random.Decimal(100, 1000),
                        faker.Image.PicsumUrl(imageId: i),
                        faker.Commerce.ProductDescription(),
                        category.Id,
                        productCode
                        );
                    products.Add(product);
                }

                context.AddRange(products);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<CatalogoDbContext>();
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
    }
}