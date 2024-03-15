using MongoDB.Bson;

namespace Notes.Web.Infrastructure.Mongo.Documents;

internal sealed class Note
{
    public ObjectId Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
