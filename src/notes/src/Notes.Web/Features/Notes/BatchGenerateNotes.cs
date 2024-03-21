using MongoDB.Driver;
using Notes.Web.Infrastructure.Mongo.Documents;

namespace Notes.Web.Features.Notes;

internal static partial class NotesEndpoints
{
    public static async Task<IResult> BatchGenerateNotes(BatchGenerateNotesRequest request, IMongoCollection<Note> notesCollection, CancellationToken cancellationToken)
    {
        List<Note> notes = new(request.Amount);
        for (int index = 0; index < request.Amount; index++)
        {
            var guid = Guid.NewGuid();
            notes.Add(new()
            {
                Title = $"Title_{guid}",
                Content = $"Content_{guid}"
            });
        }

        await notesCollection.InsertManyAsync(notes, new InsertManyOptions
        {
            IsOrdered = false,
            Comment = "Batch generate notes comment..."
        }, cancellationToken);

        return TypedResults.NoContent();
    }
}

internal sealed record BatchGenerateNotesRequest(
    int Amount
);