using FluentValidation;
using MediatR;
using Todo.SqlServer;
using Todo.Web.Api.Extensions;

namespace Todo.Web.Api.Features;

internal sealed class CreateTodoList : IEndpoint
{
    public WebApplication AddEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("todo-lists", async (CreateTodoListRequest request, ISender sender, CancellationToken cancellationToken) =>
        {

        });
    }
}

public sealed class CreateTodoListRequest
{
    public string Title { get; init; } = string.Empty;
}

public sealed class CreateTodoListRequestValidator : AbstractValidator<CreateTodoListRequest>
{
    public CreateTodoListRequestValidator()
    {
        RuleFor(request => request.Title)
            .NotEmpty();
    }
}

public sealed class CreateTodoListCommand : IRequest
{
    public CreateTodoListCommand()
    {

    }
}

public sealed class CreateTodoListCommandHandler(
    ILogger<CreateTodoListCommandHandler> logger, TodoDatabaseContext context) : IRequestHandler<CreateTodoListCommand>
{
    private readonly ILogger<CreateTodoListCommandHandler> _logger = logger;
    private readonly TodoDatabaseContext _context = context;

    public async Task Handle(CreateTodoListCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);


    }
}