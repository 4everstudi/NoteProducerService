using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NoteProducerService.Request;
using NoteProducerService.Response;
using NoteProducerService.Service;
using RabbitMQ.Client;

namespace NoteProducerService.Controllers
{
    [Route("api/[controller]")]
    public class NoteController : Controller
    {
        INoteProductionSender _noteProductionSender;
        public NoteController(INoteProductionSender noteProductionSender)
        {
            _noteProductionSender = noteProductionSender;
        }

        public IActionResult Index()
        {
            _noteProductionSender.Send("1", "2", "s3");
            return View();
        }
    }
}
