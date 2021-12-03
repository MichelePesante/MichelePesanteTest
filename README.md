# MichelePesanteTest

Hello! This is a test project that retrieves documents from an AzureCosmosDB and displays them as a stringified JSON.
For test purposes I also added a page where you can add documents to the DB with the correct format.
Authentication login and secret can be found in appsettings.json

This project also provides controllers that can be called from external services through REST APIs.

https://michelepesantetest.azurewebsites.net/api/authenticate --> You need to retrieve token from here, otherwise you can't access other APIs

As I wrote above, from now on you need to call the APIs with the Bearer Token given from the authentication response.

https://michelepesantetest.azurewebsites.net/api/storage/get/{id} ------------->  Retrieve the document with the given id
https://michelepesantetest.azurewebsites.net/api/storage/get/{id}/processes --->  Retrieve the processes of the document with the given id
https://michelepesantetest.azurewebsites.net/api/storage/get/all -------------->  Retrieve all documents with other info
https://michelepesantetest.azurewebsites.net/api/storage/get/filtered/{date} -->  Retrieve info and documents created after the given date
https://michelepesantetest.azurewebsites.net/api/storage/upload --------------->  Upload a document with correct JSON format
