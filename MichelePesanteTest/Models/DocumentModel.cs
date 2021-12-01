using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MichelePesanteTest.Models
{
    public class DocumentModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string ExternalId { get; set; }
        public string Category { get; set; }
        public string ReceptionDate { get; set; }
        public string Signature { get; set; }
        public List<Process> Processes { get; set; }
    }

    public class Process
    {
        public string Type { get; set; }
        public string ExecutionTime { get; set; }
        public string Result { get; set; }
    }
}
