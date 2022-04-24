# case_study_retail_store

# About The Project

This project is written in Visual Studio Code and created from CLI.
The project contains the following entities
    #####Customer
    #####CustomerType
    #####DiscountDefinition
    #####Product
    #####ProductType
    #####Invoice
    #####InvoiceDetail

## Installation

    git@github.com:barisakr/case_study_retail_store.git

After the installation the solution needs to be restored

    dotnet restore


## Run the App

    cd Api
    dotnet watch run



## REST API

The REST API to the example app is described below.

#### #Get Customers

##### Request

curl -X 'GET' \
  'https://localhost:5001/api/Customer' \
  -H 'accept: text/plain'

#### #Get Customer By Id

##### Request

curl -X 'GET' \
  'https://localhost:5001/api/Customer/1' \
  -H 'accept: text/plain'

#### #Get Invoices

##### Request

curl -X 'GET' \
  'https://localhost:5001/api/Invoice/Invoices' \
  -H 'accept: text/plain'

#### #Create An Invoice for A Customer

##### Request

curl -X 'POST' \
  'https://localhost:5001/api/Invoice/CreateAnInvoiceForACustomer?customerId=1' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "invoiceNumber": "string",
  "invoiceDetails": [
    {
      "quantity": 0,
      "product": {
        "id": 0
      }
    }
  ]
}'

## License
[MIT](https://choosealicense.com/licenses/mit/)
