using MongoDB.Driver;
using Notes.Web.Infrastructure.Mongo.Documents;

namespace Notes.Web.Features.Notes;

internal static partial class NotesEndpoints
{
    public static async Task<IResult> ListNotes(IMongoCollection<Note> notesCollection, CancellationToken cancellationToken)
    {
        using var cursor = await notesCollection.FindAsync(note => true, new FindOptions<Note>
        {
            BatchSize = 10,
            Limit = 100
        }, cancellationToken);

        var notes = await cursor.ToListAsync(cancellationToken);

        var response = new ListNotesResponse
        {
            Notes = notes.Select(note => new ListNotesResponse.ListNotesResponseNote
            {
                Id = note.Id.ToString(),
                Title = note.Title,
                Content = note.Content
            }).ToArray()
        };

        return Results.Ok(response);
    }
}

internal sealed record ListNotesResponse
{
    public required IReadOnlyCollection<ListNotesResponseNote> Notes { get; init; }

    public sealed record ListNotesResponseNote
    {
        public required string Id { get; init; }

        public required string Title { get; init; }

        public required string Content { get; init; }
    }
}