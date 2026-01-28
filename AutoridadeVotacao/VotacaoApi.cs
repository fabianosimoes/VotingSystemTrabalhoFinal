using System;
using System.Net.Http;
using Grpc.Net.Client;
using VotingSystem.Voting;

namespace AutoridadeVotacao
{
    internal static class VotacaoApi
    {
        // Endpoint remoto (em vez de https://localhost:9091)
        private const string GrpcEndpoint = "https://ken01.utad.pt:9091";

        private static readonly VotingService.VotingServiceClient _client;

        static VotacaoApi()
        {
            // Handler para aceitar certificados não confiáveis (APENAS para testes)
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            // Canal gRPC
            var channel = GrpcChannel.ForAddress(
                GrpcEndpoint,
                new GrpcChannelOptions
                {
                    HttpHandler = handler
                });

            // Cliente gerado pelo proto
            _client = new VotingService.VotingServiceClient(channel);
        }

        public static VotingService.VotingServiceClient Client => _client;
    }
}