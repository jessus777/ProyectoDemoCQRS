
using Application.Features.Customer.Commands.DeleteCustomer;
using Application.Features.Customer.Commands.EditCustomer;
using Application.Features.Customer.Queries.GetAllCustomer;
using Application.Features.Customer.Queries.GetCustomerById;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_Back_End_MinimalApiDemo.EndPoints
{
    public static class CustomerEndPoints
    {

        public static WebApplication CustomerEndpoints(
         this WebApplication app)
        {   
            app.MapPost("api/createCustomer", async ([FromBody] CreateCustomerCommand command, IMediator mediator, CancellationToken token)
                => Results.Ok(await mediator.Send(command,token))
                )
                .WithTags("Customer");

            app.MapPut("api/updateCustomer", async ([FromBody] EditCustomerCommand command, IMediator mediator, CancellationToken token)
                => Results.Ok(await mediator.Send(command, token))
                )
                .WithTags("Customer");

            app.MapDelete("api/deleteCustomer/{id}", async (int id, IMediator mediator, CancellationToken token)
                => Results.Ok(await mediator.Send(new DeleteCustomerCommand() { Id = id}, token))
                )
                .WithTags("Customer");

            app.MapGet("api/getCustomersList", async (IMediator mediator, CancellationToken token)
                => Results.Ok(await mediator.Send(new GetAllCustomerQuery(), token))
                )
                .WithTags("Customer");

            app.MapGet("api/getCustomers/{id}", async (int id, IMediator mediator, CancellationToken token)
                => Results.Ok(await mediator.Send(new GetCustomerByIdQuery() { Id = id }, token))
                )
                .WithTags("Customer");

            return app;
        }
    }
}
