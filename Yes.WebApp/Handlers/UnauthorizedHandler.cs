using System.Net;

namespace Yes.WebApp.Handlers;

public class UnauthorizedHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var httpResponse = await base.SendAsync(request, cancellationToken);

        if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
        {
            httpResponse.Dispose();
            throw new UnauthorizedAccessException();
        }

        return httpResponse;
    }
}
