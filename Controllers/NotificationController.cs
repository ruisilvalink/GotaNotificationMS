using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GotaNotificationMS.Models;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System.Text;

namespace GotaNotificationMS.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        [HttpGet("")]
        public IActionResult IsOK(){
            return Ok("OK");
        }

        [HttpGet("[action]")]
        public IActionResult Hello(){
            return Json( new { say = "hello"});
        }
        
        [HttpGet("[action]")]
        public void SendMessage() {
            var config = new Dictionary<string, object> 
            { 
                { "bootstrap.servers", "localhost:9092" } 
            };

            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {
                var dr = producer.ProduceAsync("test", null, "test message text").Result;
                Console.WriteLine($"Delivered '{dr.Value}' to: {dr.TopicPartitionOffset}");
            }
        }
    }
}