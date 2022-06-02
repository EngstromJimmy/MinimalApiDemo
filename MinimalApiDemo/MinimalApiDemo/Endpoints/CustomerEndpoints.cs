using MinimalApiDemo.Services;

namespace MinimalApiDemo.Endpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this WebApplication app)
    {
        app.MapGet("Customers/", async (CustomerService service) =>
        {
            var customers = await service.GetCustomersAsync();
            return Results.Ok(customers);
        });

        app.MapGet("Customers/{id}", async (CustomerService service, int id) =>
        {
            var customer = await service.GetCustomerAsync(id);
            if (customer == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(customer);
        });
    }
}
