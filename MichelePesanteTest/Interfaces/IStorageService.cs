using MichelePesanteTest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MichelePesanteTest.Interfaces
{
    public interface IStorageService
    {
        Task<DocumentModel> GetDocumentByID(string id);
        Task<List<DocumentModel>> GetAllDocuments();
        Task<List<DocumentModel>> GetFilteredDocuments(DateTime date);
        Task UploadDocument(DocumentModel document);
    }
}
