using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteProducerService.Service
{
    public interface INoteProductionSender
    {
        void Send(string v1, string v2, string v3);
    }
}
