namespace Todo.Web.Api.Extensions;

internal interface IEndpoint
{
    WebApplication AddEndpoint(IEndpointRouteBuilder builder);
}
