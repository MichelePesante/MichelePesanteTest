using MichelePesanteTest.Interfaces;
using MichelePesanteTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MichelePesanteTest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/")]
    public class StorageController : Controller
    {
        private readonly IStorageService storageService;

        public StorageController(IStorageService _storageService)
        {
            storageService = _storageService;
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<DocumentModel> GetDocumentByID(string id)
        {
            return await storageService.GetDocumentByID(id);
        }

        [HttpGet]
        [Route("get/all")]
        public async Task<List<DocumentModel>> GetAllDocuments()
        {
            return await storageService.GetAllDocuments();
        }
    }
}
