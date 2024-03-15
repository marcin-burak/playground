using Microsoft.Extensions.Options;

namespace Notes.Web.Infrastructure.Mongo;

//TODO: Should we create IOptions<T> as records?
public sealed record MongoOptions
{
    public required string Connection { get; init; }

    public required string Database { get; init; }
}

public sealed class MongoOptionsValidation : IValidateOptions<MongoOptions>
{
    public ValidateOptionsResult Validate(string? name, MongoOptions options)
    {
        List<string> errors = [];


        var connectionHasErrors = false;

        if (connectionHasErrors is false && string.IsNullOrWhiteSpace(options.Connection))
        {
            errors.Add("Mongo connection is required.");
            connectionHasErrors = true;
        }

        if (connectionHasErrors is false && options.Connection.Length != options.Connection.Trim().Length)
        {
            errors.Add("Mongo connection has to be trimmed.");
            connectionHasErrors = true;
        }

        const string mongoDbConnectionPrefix = "mongodb://";
        if (connectionHasErrors is false && options.Connection.StartsWith(mongoDbConnectionPrefix) is false)
        {
            errors.Add($"Mongo connection has to start with '{mongoDbConnectionPrefix}' prefix.");
        }



        var databaseHasErrors = false;

        if (databaseHasErrors is false && string.IsNullOrWhiteSpace(options.Database))
        {
            errors.Add("Mongo database is required.");
            databaseHasErrors = true;
        }

        if (databaseHasErrors is false && options.Database.Length != options.Database.Trim().Length)
        {
            errors.Add("Mongo database has to be trimmed.");
        }



        if (errors.Count > 0)
        {
            return ValidateOptionsResult.Fail(errors);
        }

        return ValidateOptionsResult.Success;
    }
}