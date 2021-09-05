package models

type ContractDTO struct {
	Address    string
	PrivateKey string
	WeiDeposit int64
	GasLimit   uint64
	GasPrice   int64
}

type ClaimPaymentDTO struct {
	ContractAddress  string
	Amount           int64
	RenterPrivateKey string
	RecipientAddress string
}
