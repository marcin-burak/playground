using System.Linq.Expressions;

Expression<Func<User, object>> selectMembersExpression = user => new { user.FirstName, user.LastName };

User user = new()
{
    FirstName = "John",
    LastName = "Smith",
    Age = 20
};

if (selectMembersExpression.Body is NewExpression newExpression && newExpression.Members is not null)
{
    var selectedMemberNames = newExpression.Members.Select(member => member.Name).ToArray();
}

#region Models

public sealed class User
{
    public required string FirstName { get; init; } = string.Empty;

    public required string LastName { get; init; } = string.Empty;

    public required int Age { get; init; }
}

#endregion