using MichelePesanteTest.Models;
using MichelePesanteTest.Settings;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MichelePesanteTest.Helpers
{
    public class StorageHelper
    {
        private readonly StorageSettings storageSettings;
        private readonly string databaseName;
        private readonly string containerName;
        private CosmosClient cosmosClient;
        private Container container;

        public StorageHelper(IOptions<StorageSettings> _storageSettings)
        {
            storageSettings = _storageSettings.Value;
            databaseName = storageSettings.CosmosDatabaseID;
            containerName = storageSettings.CosmosContainerID;
        }

        private void InitializeCosmosConnection()
        {
            try
            {
                if (cosmosClient == null)
                    cosmosClient = new CosmosClient(storageSettings.CosmosConnectionString);

                if (container == null)
                    container = cosmosClient.GetContainer(databaseName, containerName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DocumentModel> GetDocumentByIDAsync(string id)
        {
            InitializeCosmosConnection();
            return await container.ReadItemAsync<DocumentModel>(id, PartitionKey.None);
        }

        public async Task<List<DocumentModel>> GetAllDocumentsAsync()
        {
            InitializeCosmosConnection();
            var query = new QueryDefinition("SELECT * FROM c");
            return (await container.GetItemQueryIterator<DocumentModel>(query).ReadNextAsync()).ToList();
        }

        public async Task<List<DocumentModel>> GetFilteredDocuments(DateTime date)
        {
            InitializeCosmosConnection();
            var query = new QueryDefinition("SELECT * FROM c WHERE c.ReceptionDate >= @date").WithParameter("@date", date);
            return (await container.GetItemQueryIterator<DocumentModel>(query).ReadNextAsync()).ToList();
        }

        public async Task UploadDocumentAsync(DocumentModel document)
        {
            InitializeCosmosConnection();
            await container.CreateItemAsync(document);
        }
    }
}
