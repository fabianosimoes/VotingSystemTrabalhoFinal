

using System.Security.Cryptography;
using System.Threading.Tasks;
using Grpc.Core;
using VotingSystem;

public class VoterRegistrationServiceImpl : VoterRegistrationService.VoterRegistrationServiceBase
{
    public override Task<VoterResponse> IssueVotingCredential(
        VoterRequest request,
        ServerCallContext context)
    {
        var credential = GenerateRandomCredential();

        var response = new VoterResponse
        {
            IsEligible = true,
            VotingCredential = credential
        };

        return Task.FromResult(response);
    }

    private static string GenerateRandomCredential()
    {
        var bytes = RandomNumberGenerator.GetBytes(32);
        return Convert.ToBase64String(bytes);
    }
}
