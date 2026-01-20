
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Net.Client;
using VotingSystem.Voting;


namespace AutoridadeRegisto
{

        internal class VotacaoApiAR
        {
            private static readonly VotingService.VotingServiceClient _client;

            static VotacaoApiAR()
            {
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback =
                        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                var channel = GrpcChannel.ForAddress(
                         "https://localhost:9091",// "https://ken01.uatd.pt:9091",//
                    new GrpcChannelOptions { HttpHandler = handler });

                _client = new VotingService.VotingServiceClient(channel);
            }

            public static VotingService.VotingServiceClient Client => _client;
        }

}
