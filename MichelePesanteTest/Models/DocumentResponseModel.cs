using System.Collections.Generic;

namespace MichelePesanteTest.Models
{
    public class DocumentResponseModel
    {
        public int DocumentsNumber { get; set; }
        public Dictionary<string, int> CategoriesInfo { get; set; }
        public List<DocumentModel> Documents { get; set; }
    }
}
