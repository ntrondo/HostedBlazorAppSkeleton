using Messages.ClientServer;

namespace Web.Shared.Queries
{
    public record CounterQuery(int Count):IRemoteQuery<ServerCount>;
    public record ServerCount(int NewCount, string? ServerProcessName);
}
