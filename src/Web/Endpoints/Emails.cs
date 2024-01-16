using Kore.Application.Emails.Commands;

namespace Kore.Web.Endpoints;

public class Emails : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(SendEmail);
    }

    public async Task<IResult> SendEmail(ISender sender, CreateSmtpEmailSendCommand command)
    {
        await sender.Send(command);
        return Results.NoContent();
    }
}
