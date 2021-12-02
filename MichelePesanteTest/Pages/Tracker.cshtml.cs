using MichelePesanteTest.Interfaces;
using MichelePesanteTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MichelePesanteTest.Pages
{
    [BindProperties(SupportsGet = true)]
    public class Tracker : PageModel
    {
        private readonly IStorageService storageService;
        public string ID { get; set; }
        public string Processes { get; set; }
        public string DocumentGet { get; set; }
        public string DocumentPost { get; set; }
        public string Documents { get; set; }

        public Tracker(IStorageService _storageService)
        {
            storageService = _storageService;
        }

        public async Task OnGetDocumentAsync()
        {
            var doc = await GetDocument();
            DocumentGet = JsonConvert.SerializeObject(doc, Formatting.Indented);
        }

        public async Task OnGetProcessesAsync()
        {
            var doc = await GetDocument();
            Processes = JsonConvert.SerializeObject(doc.Processes, Formatting.Indented);
        }

        public async Task OnGetDocumentsAsync()
        {
            Documents = null;
            Documents = JsonConvert.SerializeObject(await storageService.GetAllDocuments(), Formatting.Indented);
        }

        public async Task OnPostUploadAsync()
        {
            var doc = JsonConvert.DeserializeObject<DocumentModel>(DocumentPost);
            await storageService.UploadDocument(doc);
        }

        private async Task<DocumentModel> GetDocument()
        {
            DocumentGet = null;
            return await storageService.GetDocumentByID(ID);
        }
    }
}
