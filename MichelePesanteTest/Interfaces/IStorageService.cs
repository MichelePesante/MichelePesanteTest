using MichelePesanteTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MichelePesanteTest.Interfaces
{
    public interface IStorageService
    {
        Task<DocumentModel> GetDocumentByID(string id);
        Task<List<DocumentModel>> GetAllDocuments();
    }
}
