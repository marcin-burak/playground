using MongoDB.Driver;
using Notes.Web.Infrastructure.Mongo.Documents;

namespace Notes.Web.Features.Notes;

internal static partial class NotesEndpoints
{
    public static async Task<IResult> CreateNote(CreateNoteRequest request, IMongoCollection<Note> notesCollection, IMongoClient client, CancellationToken cancellationToken)
    {
        await client.ListDatabaseNamesAsync(cancellationToken);

        Note note = new()
        {
            Title = request.Title,
            Content = request.Content
        };

        await notesCollection.InsertOneAsync(note, new InsertOneOptions(), cancellationToken);

        return TypedResults.NoContent();
    }
}

#region Contracts

internal sealed record CreateNoteRequest(
    string Title,
    string Content
);

#endregion