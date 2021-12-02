using MichelePesanteTest.Interfaces;
using MichelePesanteTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [Route("get/{id}/processes")]
        public async Task<List<Process>> GetDocumentProcesses(string id)
        {
            var documents = await storageService.GetDocumentByID(id);
            return documents.Processes;
        }

        [HttpGet]
        [Route("get/all")]
        public async Task<List<DocumentModel>> GetAllDocuments()
        {
            return await storageService.GetAllDocuments();
        }

        [HttpGet]
        [Route("get/filtered/{date}")]
        public async Task<List<DocumentModel>> GetFilteredDocuments(DateTime date)
        {
            return await storageService.GetFilteredDocuments(date);
        }

        [HttpPost]
        [Route("upload")]
        public async Task UploadDocument(DocumentModel document)
        {
            await storageService.UploadDocument(document);
        }
    }
}
