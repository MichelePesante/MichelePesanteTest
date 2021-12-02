using System.Collections.Generic;

namespace MichelePesanteTest.Models
{
    public class DocumentResponseModel
    {
        public int DocumentsNumber { get; set; }
        public int CategoriesNumber { get; set; }
        public List<string> Categories { get; set; }
        public List<DocumentModel> Documents { get; set; }
    }
}
