using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClientMonitor.Client;

namespace TwitterClientMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Consumer consumer = new 
            //    Consumer("AWRaH6JYes1VQD5CqGlSdyUOl", 
            //                "dvPJq7c5Hfe1mZh5uunUyXJ7DayZgMmmkT40ED3e85DHUjVhi1",
            //                    //new List<string> { "#ExNaMTV", "Rei Leão", "Fernando Miguel", "Simba", "Rodrigo Caio", "#DeFeriasComOExbrasil" });
            //                    new List<string> { "#ExNaMTV","Rei Leão" });

            Console.WriteLine($"{DateTime.Now} - Start App");

            var app = ConfigurationManager.AppSettings["AppName"].ToString();

            Orchestrator orchestrator = new Orchestrator(app);

            orchestrator.Magic();
        }
    }
}
