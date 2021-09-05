package main

import (
	"net/http"
	"solidity/env"
	"solidity/handlers"

	"github.com/ethereum/go-ethereum/ethclient"
)

func main() {
	env.EthClient, _ = ethclient.Dial("http://127.0.0.1:7545")

	http.HandleFunc("/deployContract", handlers.CreateContractHandler)
	http.HandleFunc("/claimPayment", handlers.ClaimPaymentHandler)
	http.HandleFunc("/shutdownContract", handlers.ShutdownContractHandler)

	http.ListenAndServe(":8080", nil)
}
