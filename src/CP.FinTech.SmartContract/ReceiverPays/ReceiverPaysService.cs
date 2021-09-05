using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using RestSharp;

namespace Solidity.Contracts.ReceiverPays
{
    public partial class ReceiverPaysService
    {
        public EthNodeAPI eth = new EthNodeAPI("http://localhost:8080");

        public string recipientAddress = "0x35F36875e1bda15f140E8Ead512a98f91BBD9FB4";
        public string renterPrivateKey = "072b93ef9b5d3056fe3c6c1178dd60387d2455667171b8176712290b2c2417c4";
        public class ContractDetailsDTO
        {
            public string Address { get; set; }
            public string PrivateKey { get; set; }
            public long WeiDeposit { get; set; }
            public ulong GasLimit { get; set; }
            public long GasPrice { get; set; }
        }
        public class ClaimPaymentDTO
        {
            public string ContractAddress { get; set; }
            public long Amount { get; set; }
            public string RenterPrivateKey { get; set; }
            public string RecipientAddress { get; set; }
        }
        public class EthNodeAPI
        {
            private readonly RestClient client;
            public EthNodeAPI(string host) => client = new RestClient(host);
            private string PerformRequest<T>(RestRequest rq)
            {
                var response = client.Post<T>(rq);
                return response.StatusCode == System.Net.HttpStatusCode.OK ? response.Content : $"[Error] {response.Content}";
            }
            public bool StrResponseOk(string response) => response != null && response.Contains("0x");
            public string DeployContract(ContractDetailsDTO dc)
            {
                var request = new RestRequest("deployContract");
                request.AddJsonBody(dc);
                return PerformRequest<string>(request);
            }
            public string ClaimPayment(ClaimPaymentDTO cp)
            {
                var request = new RestRequest("claimPayment");
                request.AddJsonBody(cp);
                return PerformRequest<string>(request);
            }
            public string ShutdownContract(ContractDetailsDTO dc)
            {
                var request = new RestRequest("shutdownContract");
                request.AddJsonBody(dc);
                return PerformRequest<string>(request);
            }
        }

    }
}
