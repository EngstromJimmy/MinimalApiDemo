# Using Minimal API in larger APIs
I have heard from multiple people that Minimal APIs should only be used if your project is quite small. 
If you have a lot of API endpoints then it would be probably better to use controllers.
One of the biggest selling points of minimal APIs is that you can have all the APIs in one file, less ceremony, and quicker to set up.
Minimal APIs have a really nice API surface with dependency injection and handling of parameters and all of that goodness. I think that even if you have a really big API, you could use minimal API simply because they are in my opinion (just as they claim to be) easier, quicker, and nicer to work with.

This is how we do it.  
First of all, we have created extension methods where we define our endpoints. So now we have different classes defining different endpoints. This way we won't have everything in one file. We're calling these extension methods from our program.cs. Inside of the endpoints we are injecting services, services that are testable, services that are only injected into the methods that used them, and it makes the endpoint code really small.

We create an extension method class for each endpoint collection we would like to group (kinda the same way we would group things in a controller).

``` csharp

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
```
In the extension method, we keep the code that is specific for the API, everything else is in a service.
This way we can group APIs, make it more testable and still make use of the awesome minimal APIs.
Then we simply call the extension method from inside program.cs to set everything up.
``` csharp
app.MapCustomerEndpoints();
```













