using Notes.Web.Features.Notes;

namespace Notes.Web.Features;

internal static class Endpoints
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/v1");

        var notes = group.MapGroup("notes");
        notes.MapPost("", NotesEndpoints.CreateNote);
        notes.MapGet("", NotesEndpoints.ListNotes);

        return app;
    }
}
