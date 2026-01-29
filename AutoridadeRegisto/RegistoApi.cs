using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Grpc.Net.Client;
using VotingSystem; // do voter.proto ...


namespace AutoridadeRegisto
{
    internal static class RegistoApi
    {
        private static readonly VoterRegistrationService.VoterRegistrationServiceClient _client;

        // construtor estático: corre 1 vez
        static RegistoApi()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var channel = GrpcChannel.ForAddress(
             // "https://localhost:9093", // ESTE MOCK CONTEM A FEATURE PARA IMPEDIR A DUPLICAÇÃO DOS VOTOS. COMENTE O ENDPOINT ABAIXO E DESCOMENTE ESTE PARA EXPERIMENTAR
              "https://ken01.utad.pt:9091", //
                new GrpcChannelOptions { HttpHandler = handler });

            _client = new VoterRegistrationService.VoterRegistrationServiceClient(channel);
        }

        public static VoterRegistrationService.VoterRegistrationServiceClient Client => _client;
    }
}
