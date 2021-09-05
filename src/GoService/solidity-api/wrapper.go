package api

import (
	"bytes"
	"context"
	"crypto/ecdsa"
	"errors"
	"fmt"
	"log"
	"math/big"
	"solidity/env"
	"solidity/models"

	"github.com/ethereum/go-ethereum/accounts/abi/bind"
	"github.com/ethereum/go-ethereum/common"
	"github.com/ethereum/go-ethereum/core/types"
	"github.com/ethereum/go-ethereum/crypto"
	solsha3 "github.com/miguelmota/go-solidity-sha3"
)

func getNextNonce(pk string) (int64, error) {
	privateKey, err := crypto.HexToECDSA(pk)
	if err != nil {
		panic(err)
	}

	publicKey := privateKey.Public()
	publicKeyECDSA, ok := publicKey.(*ecdsa.PublicKey)
	if !ok {
		return 0, errors.New("invalid key")
	}

	fromAddress := crypto.PubkeyToAddress(*publicKeyECDSA)
	nonce, err := env.EthClient.PendingNonceAt(context.Background(), fromAddress)
	if err != nil {
		return 0, err
	}
	return int64(nonce), nil
}

func DeployContract(contractDTO models.ContractDTO) (string, error) {
	privateKey, err := crypto.HexToECDSA(contractDTO.PrivateKey)
	if err != nil {
		return "", err
	}

	nonce, err := getNextNonce(contractDTO.PrivateKey)
	if err != nil {
		return "", err
	}

	chainID, err := env.EthClient.ChainID(context.Background())
	if err != nil {
		return "", err
	}

	auth, err := bind.NewKeyedTransactorWithChainID(privateKey, chainID)
	if err != nil {
		return "", err
	}
	auth.Nonce = big.NewInt(int64(nonce))
	auth.Value = big.NewInt(contractDTO.WeiDeposit) // in wei
	auth.GasLimit = contractDTO.GasLimit            // in units
	auth.GasPrice = big.NewInt(contractDTO.GasPrice)

	address, tx, instance, err := DeployApi(auth, env.EthClient)
	if err != nil {
		return "", err
	}

	_, _ = instance, tx

	return address.Hex(), nil
}

func ShutdownContract(contract models.ContractDTO) (string, error) {
	conn, err := NewApi(common.HexToAddress(contract.Address), env.EthClient)
	if err != nil {
		return "", err
	}
	nonce, err := getNextNonce(contract.PrivateKey)
	if err != nil {
		return "", err
	}
	tx, err := conn.Shutdown(&bind.TransactOpts{
		GasPrice: big.NewInt(contract.GasPrice),
		GasLimit: contract.GasLimit,
		Nonce:    big.NewInt(nonce),
		Signer: func(a common.Address, t *types.Transaction) (*types.Transaction, error) {
			privateKey, err := crypto.HexToECDSA(contract.PrivateKey)
			if err != nil {
				return nil, err
			}
			chainID, err := env.EthClient.ChainID(context.Background())
			if err != nil {
				return nil, err
			}
			signedTx, _ := types.SignTx(t, types.NewEIP155Signer(chainID), privateKey)
			return signedTx, nil
		},
	})
	if err != nil {
		return "", err
	}
	return tx.Hash().Hex(), nil
}

func ethSignMessage(message []byte, privateKey string) ([]byte, error) {
	privatekeyPtr, err := crypto.HexToECDSA(privateKey)
	if err != nil {
		return nil, err
	}
	publicKey := privatekeyPtr.Public()
	publicKeyECDSA, ok := publicKey.(*ecdsa.PublicKey)
	if !ok {
		log.Fatal("error casting public key to ECDSA")
	}
	publicKeyBytes := crypto.FromECDSAPub(publicKeyECDSA)
	//prefix := "\x19Ethereum Signed Message\n"
	//preSigned := prefix + strconv.Itoa(len(message)) + message
	hashRaw := crypto.Keccak256Hash(message)
	signatureBytes, err := crypto.Sign(hashRaw.Bytes(), privatekeyPtr)
	if err != nil {
		return nil, err
	}

	sigPublicKey, err := crypto.Ecrecover(hashRaw.Bytes(), signatureBytes)

	if err != nil {
		return nil, err
	}

	matches := bytes.Equal(sigPublicKey, publicKeyBytes)
	fmt.Println(matches) // true

	sigPublicKeyECDSA, err := crypto.SigToPub(hashRaw.Bytes(), signatureBytes)
	if err != nil {
		log.Fatal(err)
	}

	sigPublicKeyBytes := crypto.FromECDSAPub(sigPublicKeyECDSA)
	matches = bytes.Equal(sigPublicKeyBytes, publicKeyBytes)
	fmt.Println(matches) // true

	signatureNoRecoverID := signatureBytes[:len(signatureBytes)-1] // remove recovery id
	verified := crypto.VerifySignature(publicKeyBytes, hashRaw.Bytes(), signatureNoRecoverID)
	fmt.Println(verified) // true

	return signatureBytes, nil
}

func signPayment(cp models.ClaimPaymentDTO) ([]byte, error) {
	nonce, err := getNextNonce(cp.RenterPrivateKey)
	if err != nil {
		return nil, err
	}
	hash := solsha3.SoliditySHA3(
		solsha3.Address(cp.RecipientAddress),
		solsha3.Uint256(big.NewInt(cp.Amount)),
		solsha3.Uint256(big.NewInt(nonce)),
		solsha3.Address(cp.ContractAddress),
	)

	signature, err := ethSignMessage(hash, cp.RenterPrivateKey)
	if err != nil {
		return nil, err
	}
	return signature, nil
}

func ClaimPayment(cp models.ClaimPaymentDTO) (string, error) {
	conn, err := NewApi(common.HexToAddress(cp.ContractAddress), env.EthClient)
	if err != nil {
		return "", err
	}
	nonce, err := getNextNonce(cp.RenterPrivateKey)
	if err != nil {
		return "", err
	}
	// signature, err := signPayment(cp)
	// if err != nil {
	// 	return "", err
	// }
	tx, err := conn.ClaimPayment(
		&bind.TransactOpts{
			Nonce: big.NewInt(nonce),
			Signer: func(a common.Address, t *types.Transaction) (*types.Transaction, error) {
				privateKey, err := crypto.HexToECDSA(cp.RenterPrivateKey)
				if err != nil {
					return nil, err
				}
				chainID, err := env.EthClient.ChainID(context.Background())
				if err != nil {
					return nil, err
				}
				signedTx, _ := types.SignTx(t, types.NewEIP155Signer(chainID), privateKey)
				return signedTx, nil
			},
		},
		//signature,
		//big.NewInt(nonce),
		big.NewInt(cp.Amount),
	)
	if err != nil {
		return "", err
	}
	return tx.Hash().Hex(), nil
}
