using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Solidity.Contracts.ReceiverPays.ContractDefinition
{


    public partial class ReceiverPaysDeployment : ReceiverPaysDeploymentBase
    {
        public ReceiverPaysDeployment() : base(BYTECODE) { }
        public ReceiverPaysDeployment(string byteCode) : base(byteCode) { }
    }

    public class ReceiverPaysDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6080604052600080546001600160a01b03191633179055610474806100256000396000f3fe608060405234801561001057600080fd5b50600436106100575760003560e01c806352c791611461005c5780636f9fb98a146100715780638da5cb5b1461008557806398ba6496146100b0578063fc0e74d1146100e3575b600080fd5b61006f61006a36600461034b565b6100eb565b005b604051303181526020015b60405180910390f35b600054610098906001600160a01b031681565b6040516001600160a01b03909116815260200161007c565b6100d36100be36600461040f565b60016020526000908152604090205460ff1681565b604051901515815260200161007c565b61006f610283565b60008281526001602052604090205460ff16156101425760405162461bcd60e51b815260206004820152601060248201526f4475706c6963617465204e6f6e63652160801b60448201526064015b60405180910390fd5b6000828152600160208181526040808420805460ff191690931790925581516bffffffffffffffffffffffff1933606090811b821683850152603483018790526054830188905230901b166074820152825180820360680181526088820184528051908301207f19457468657265756d205369676e6564204d6573736167653a0a33320000000060a883015260c4808301919091528351808303909101815260e4909101909252815191012090546001600160a01b0316610203828661029d565b6001600160a01b03161461024f5760405162461bcd60e51b8152602060048201526013602482015272556e61626c6520746f20417574686f72697a6560681b6044820152606401610139565b604051339083156108fc029084906000818181858888f1935050505015801561027c573d6000803e3d6000fd5b5050505050565b6000546001600160a01b0316331461029a57600080fd5b33ff5b6000806000806102ac8561031c565b6040805160008152602081018083528b905260ff8516918101919091526060810183905260808101829052929550909350915060019060a0016020604051602081039080840390855afa158015610307573d6000803e3d6000fd5b5050604051601f190151979650505050505050565b6000806000835160411461032f57600080fd5b5050506020810151604082015160609092015160001a92909190565b60008060006060848603121561036057600080fd5b833567ffffffffffffffff8082111561037857600080fd5b818601915086601f83011261038c57600080fd5b81358181111561039e5761039e610428565b604051601f8201601f19908116603f011681019083821181831017156103c6576103c6610428565b816040528281528960208487010111156103df57600080fd5b82602086016020830137600060208483010152809750505050505060208401359150604084013590509250925092565b60006020828403121561042157600080fd5b5035919050565b634e487b7160e01b600052604160045260246000fdfea26469706673582212201f4fa10c7848078b9c90ee690be15803f695d7b1a342c475eec4f94ea2dd878864736f6c63430008070033";
        public ReceiverPaysDeploymentBase() : base(BYTECODE) { }
        public ReceiverPaysDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class ClaimPaymentFunction : ClaimPaymentFunctionBase { }

    [Function("claimPayment")]
    public class ClaimPaymentFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "signature", 1)]
        public virtual byte[] Signature { get; set; }
        [Parameter("uint256", "nonce", 2)]
        public virtual BigInteger Nonce { get; set; }
        [Parameter("uint256", "amount", 3)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class GetContractBalanceFunction : GetContractBalanceFunctionBase { }

    [Function("getContractBalance", "uint256")]
    public class GetContractBalanceFunctionBase : FunctionMessage
    {

    }

    public partial class NonceMapFunction : NonceMapFunctionBase { }

    [Function("nonceMap", "bool")]
    public class NonceMapFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class ShutdownFunction : ShutdownFunctionBase { }

    [Function("shutdown")]
    public class ShutdownFunctionBase : FunctionMessage
    {

    }

    public partial class ClaimedPaymentEventDTO : ClaimedPaymentEventDTOBase { }

    [Event("ClaimedPayment")]
    public class ClaimedPaymentEventDTOBase : IEventDTO
    {
        [Parameter("address", "claimer", 1, false )]
        public virtual string Claimer { get; set; }
        [Parameter("uint256", "value", 2, false )]
        public virtual BigInteger Value { get; set; }
    }



    public partial class GetContractBalanceOutputDTO : GetContractBalanceOutputDTOBase { }

    [FunctionOutput]
    public class GetContractBalanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class NonceMapOutputDTO : NonceMapOutputDTOBase { }

    [FunctionOutput]
    public class NonceMapOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }


}
