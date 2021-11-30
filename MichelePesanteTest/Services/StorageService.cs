using MichelePesanteTest.Helpers;
using MichelePesanteTest.Interfaces;
using MichelePesanteTest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MichelePesanteTest.Services
{
    public class StorageService : IStorageService
    {
        public readonly StorageHelper storageHelper;

        public StorageService(StorageHelper _storageHelper)
        {
            storageHelper = _storageHelper;
        }

        public async Task<DocumentModel> GetDocumentByID(string id)
        {
            try
            {
                return await storageHelper.GetDocumentByID(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<DocumentModel>> GetAllDocuments()
        {
            try
            {
                return await storageHelper.GetAllDocuments();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
