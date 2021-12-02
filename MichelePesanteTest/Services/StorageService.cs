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
                return await storageHelper.GetDocumentByIDAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DocumentResponseModel> GetAllDocuments()
        {
            try
            {
                return await storageHelper.GetAllDocumentsAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DocumentResponseModel> GetFilteredDocuments(DateTime date)
        {
            try
            {
                return await storageHelper.GetFilteredDocuments(date);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UploadDocument(DocumentModel document)
        {
            try
            {
                await storageHelper.UploadDocumentAsync(document);
            }
            catch (Exception) 
            { 
                throw; 
            }
        }
    }
}
