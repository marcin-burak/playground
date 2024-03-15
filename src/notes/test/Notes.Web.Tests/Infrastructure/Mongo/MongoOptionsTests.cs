using Notes.Web.Infrastructure.Mongo;

namespace Notes.Web.Tests.Infrastructure.Mongo;

public sealed class MongoOptionsTests
{
    [Fact]
    public void MongoOptionsValidationSuceeds()
    {
        var mongoOptions = new MongoOptions
        {
            Connection = "mongodb://localhost:27017",
            Database = "Application"
        };

        var validationResult = new MongoOptionsValidation().Validate(null, mongoOptions);

        Assert.True(validationResult.Succeeded);
    }



    public static TheoryData<MongoOptions> InvalidMongoOptions =>
    [
        new()
        {
            Connection = null!,
            Database = null!
        },
        new()
        {
            Connection = string.Empty,
            Database = string.Empty
        },
        new()
        {
            Connection = "   ",
            Database = "   "
        },
        new()
        {
            Connection = " mongodb://localhost:27017",
            Database = " Database"
        },
        new()
        {
            Connection = "mongodb://localhost:27017 ",
            Database = "Database "
        },
        new()
        {
            Connection = " mongodb://localhost:27017 ",
            Database = " Database "
        },
        new()
        {
            Connection = "ongodb://localhost:27017",
            Database = "Database"
        },
        new()
        {
            Connection = "mongodb:/localhost:27017",
            Database = "Database"
        },
    ];

    [Theory]
    [MemberData(nameof(InvalidMongoOptions))]
    public void MongoOptionsValidationFails(MongoOptions mongoOptions)
    {
        var validationResult = new MongoOptionsValidation().Validate(null, mongoOptions);
        Assert.True(validationResult.Failed);
    }
}
