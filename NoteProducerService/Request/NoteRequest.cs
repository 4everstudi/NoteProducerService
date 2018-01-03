using NoteProducerService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteProducerService.Request
{
    enum Note { A=1, B, C, D, E, F, G };
    public class NoteRequest
    {
        public String requestId;
        public Originator originator;
        public Note note;
        public int sequenceNumber;
    }
}
