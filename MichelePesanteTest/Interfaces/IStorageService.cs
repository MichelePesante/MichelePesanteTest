using MichelePesanteTest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MichelePesanteTest.Interfaces
{
    public interface IStorageService
    {
        Task<DocumentModel> GetDocumentByID(string id);
        Task<DocumentResponseModel> GetAllDocuments();
        Task<DocumentResponseModel> GetFilteredDocuments(DateTime date);
        Task UploadDocument(DocumentModel document);
    }
}
