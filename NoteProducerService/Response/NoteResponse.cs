using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteProducerService.Response
{
    public class NoteResponse
    {
        public string RequestId { get; set; }
        public string SequenceNumber { get; set; }
        public string Path { get; set; }
        public int Note { get; set; }
    }
}
