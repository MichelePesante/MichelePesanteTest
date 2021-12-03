using MichelePesanteTest.Interfaces;
using MichelePesanteTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? TargetDate { get; set; }

        public Tracker(IStorageService _storageService)
        {
            storageService = _storageService;
        }

        public async Task OnGetDocumentAsync()
        {
            if (!string.IsNullOrWhiteSpace(ID))
            {
                var doc = await storageService.GetDocumentByID(ID);
                DocumentGet = JsonConvert.SerializeObject(doc, Formatting.Indented);
            }
        }

        public async Task OnGetProcessesAsync()
        {
            if (!string.IsNullOrWhiteSpace(ID))
            {
                var doc = await storageService.GetDocumentByID(ID);
                Processes = JsonConvert.SerializeObject(doc.Processes, Formatting.Indented);
            }
        }

        public async Task OnGetDocumentsAsync()
        {
            Documents = JsonConvert.SerializeObject(await storageService.GetAllDocuments(), Formatting.Indented);
        }

        public async Task OnGetFilteredAsync()
        {
            if (TargetDate != null)
            {
                Documents = JsonConvert.SerializeObject(await storageService.GetFilteredDocuments(TargetDate.Value), Formatting.Indented);
            }
        }

        public async Task OnPostUploadAsync()
        {
            if (!string.IsNullOrWhiteSpace(DocumentPost))
            {
                var doc = JsonConvert.DeserializeObject<DocumentModel>(DocumentPost);
                await storageService.UploadDocument(doc);
            }
        }
    }
}
