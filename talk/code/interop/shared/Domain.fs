namespace shared.domain

type Address = { Line1: string; Line2: string; PostCode: string }
type Person = { Name: string; Age: int; Address: Address }
