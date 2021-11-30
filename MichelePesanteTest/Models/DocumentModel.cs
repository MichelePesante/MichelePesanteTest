using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MichelePesanteTest.Models
{
    public class DocumentModel
    {
        [JsonIgnore]
        public string Category { get; set; }
        public string Partition => Category;
        public string Id { get; set; }
        public string ExternalId { get; set; }
        public DateTime? ReceptionDate { get; set; }
        public string Signature { get; set; }
        public List<Process> Processes { get; set; }
    }

    public class Process
    {
        public ProcessTypes Type { get; set; }
        public TimeSpan? ExecutionTime { get; set; }
        public string Result { get; set; }

    }

    public enum ProcessTypes
    {
        None = 0,
        Upload = 1,
        Retrieve = 2,
        Update = 3
    }
}
