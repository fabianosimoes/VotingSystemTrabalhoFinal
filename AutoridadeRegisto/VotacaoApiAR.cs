using System;
using System.Net.Http;
using Grpc.Net.Client;
using VotingSystem.Voting;

namespace AutoridadeRegisto
{
    internal static class VotacaoApiAR
    {
        // Endpoint remoto gRPC
        private const string GrpcEndpoint = "https://ken01.utad.pt:9091";

        private static readonly VotingService.VotingServiceClient _client;

        static VotacaoApiAR()
        {
            // Handler para aceitar certificados não confiáveis (APENAS para testes)
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            // Criação do canal gRPC
            var channel = GrpcChannel.ForAddress(
                GrpcEndpoint,
                new GrpcChannelOptions
                {
                    HttpHandler = handler
                });

            // Cliente gRPC gerado a partir do proto
            _client = new VotingService.VotingServiceClient(channel);
        }

        public static VotingService.VotingServiceClient Client => _client;
    }
}