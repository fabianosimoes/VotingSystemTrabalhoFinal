using Grpc.Core;
using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Threading.Tasks;
using VotingSystem;

public class VoterRegistrationServiceImpl : VoterRegistrationService.VoterRegistrationServiceBase
{
    // As 3 credenciais válidas usadas pelo Serviço B
    private static readonly string[] ValidCredentials =
    {
        "CRED-ABC-123",
        "CRED-DEF-456",
        "CRED-GHI-789"
    };

    // Registo de quem já votou / já recebeu credencial (em memória)
    // Guardamos a data-hora em UTC
    private static readonly ConcurrentDictionary<string, DateTime> _issued =
        new ConcurrentDictionary<string, DateTime>();

    public override Task<VoterResponse> IssueVotingCredential(
        VoterRequest request,
        ServerCallContext context)
    {
        // 1) Validar input
        var cc = request?.CitizenCardNumber?.Trim();

        if (string.IsNullOrWhiteSpace(cc))
        {
            return Task.FromResult(new VoterResponse
            {
                IsEligible = false,
                VotingCredential = ""
            });
        }

        // 2) Se já votou, rejeita imediatamente
        if (_issued.ContainsKey(cc))
        {
            Console.WriteLine($">> Rejeitado: {cc} já votou.");
            return Task.FromResult(new VoterResponse
            {
                IsEligible = false,
                VotingCredential = ""   // (opcional) poderia ser "ALREADY_VOTED"
            });
        }

        // 3) Emitir credencial (70% válida / 30% inválida)
        string credential;

        double p = RandomNumberGenerator.GetInt32(0, 100) / 100.0;

        if (p < 0.30)
        {
            // 30% → credencial inválida (teste)
            credential = GenerateInvalidCredential();
            Console.WriteLine(">> Enviada credencial **inválida** para teste.");

            // NOTA: não marca como votou quando a credencial é inválida
        }
        else
        {
            // 70% → credencial válida
            credential = PickValidCredential();
            Console.WriteLine(">> Enviada credencial válida.");

            // 4) Marca como já votou APENAS quando emite credencial válida
            _issued.TryAdd(cc, DateTime.UtcNow);
        }

        // 5) Resposta
        return Task.FromResult(new VoterResponse
        {
            IsEligible = true,
            VotingCredential = credential
        });
    }

    private static string PickValidCredential()
    {
        int idx = RandomNumberGenerator.GetInt32(ValidCredentials.Length);
        return ValidCredentials[idx];
    }

    private static string GenerateInvalidCredential()
    {
        // Gera uma credencial aleatória que não coincide com a lista válida
        var bytes = RandomNumberGenerator.GetBytes(6);
        return "INVALID-" + Convert.ToHexString(bytes);
    }
}