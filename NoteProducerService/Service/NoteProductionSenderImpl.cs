using Newtonsoft.Json;
using NoteProducerService.Response;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoteProducerService.Service
{
    public class NoteProductionSenderImpl : INoteProductionSender
    {
        public void Send(string requestId, string sequenceNumber, string path, int note)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "121.0.0.1",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "queue",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                var command = new NoteResponse
                {
                    RequestId = requestId,
                    SequenceNumber = sequenceNumber,
                    Path = path,
                    Note = note
                };
                string message = JsonConvert.SerializeObject(command);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "mykey",
                                     basicProperties: null,
                                     body: body);
            }
        }

        public static void LoadCPU(int seconds)
        {
            Enumerable.Range(1, Environment.ProcessorCount).AsParallel().Select(i => {
                var end = DateTime.Now + TimeSpan.FromSeconds(10);
                while (DateTime.Now < end) ;
                return i;
            }).ToList();
        }

        public void Send(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
    }
}
