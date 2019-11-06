using CoreTweet;
using CoreTweet.Streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TwitterClientMonitor.Common.Model;
using TwitterClientMonitor.Model.Create;
using TwitterClientMonitor.Util;

namespace TwitterClientMonitor.Motor
{
    public class Service
    {
        private readonly string ClassName = typeof(Service).Name;
        private readonly Authorize authorize;
        private Tokens tokens;
        private Dictionary<Task, CancellationTokenSource> tasks;
        private Configuration configuration;
        private IList<Campaign> campaigns;

       
        public Service(Configuration configuration, IList<Campaign> campaigns)
        {
            authorize = new Authorize(configuration.AppKey, configuration.Secret);
            this.configuration = configuration;
            this.campaigns = campaigns;
            tasks = new Dictionary<Task, CancellationTokenSource>();
        }

        public void Start(Func<string, string> func)
        {
            if (IsRunning())
            {
                Console.WriteLine($"{DateTime.Now} {ClassName} - Info: App listening");

                foreach (var campaign in campaigns)
                {
                    if (campaign.Active && campaign.Between())
                    {
                        if (campaign.FilterTweet.Active)
                        {
                            string text = campaign.FilterTweet.Text;
                            string sepator = campaign.FilterTweet.Sepator;

                            var tweets = Regex.Split(text, sepator);

                            foreach (var tweet in tweets)
                            {
                                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                                Task t = new Task(() =>
                                {
                                    EventAttached(func, tweet, campaign, cancellationTokenSource.Token);

                                }, cancellationTokenSource.Token);

                                tasks[t] = cancellationTokenSource;
                            }
                        }
                    }

                }

                UpTasks();

            }
            else
            {
                Console.WriteLine($"{DateTime.Now} {ClassName} - Warn: App Not listening");
            }


        }

        private void UpTasks()
        {
            Console.WriteLine($"{DateTime.Now} {ClassName} - Info: Total de Tasks a serem criadas: {tasks.Count}");

            foreach (var t in tasks)
            {
                Console.WriteLine($"{DateTime.Now} {ClassName} - Info: Iniciando Execução da Task...");
                t.Key.Start();
            }
        }

        public void Stop()
        {
            foreach (var kv in tasks)
            {
                kv.Value.Cancel();
                Thread.Sleep(2500);
                kv.Value.Dispose();
            }

            Console.WriteLine($"{DateTime.Now} {ClassName} - Warn: App Stop");
        }

        private bool IsRunning()
        {
            try
            {
                if (authorize is null)
                {
                    return false;
                }
                else
                {
                    tokens = authorize.AuthorizeService();
                    return authorize.AuthorizeIsValid();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} {ClassName} - Error:{ex.ToString()}");
                return false;
            }
        }

        private async void EventAttached(Func<string, string> func, string param, Campaign campaign, CancellationToken cancellationToken)
        {
            bool flag = true;

            while (flag && !cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine($"{DateTime.Now} {ClassName} - <{Task.CurrentId}>Info: processamento baseado no tweet:{param} da Campanha:{campaign.Name}");

                var sampleStream = tokens.Streaming.Filter(null, param, null, null).Where(x => x.Type == MessageType.Create);

                foreach (var stream in sampleStream)
                {
                    func(stream.Json);
                }

                flag = campaign.Between();

                await Task.Delay(20000);
            }

            Console.WriteLine($"{DateTime.Now} {ClassName} - <{Task.CurrentId}>Info: processamento baseado no tweet:{param} foi encerrado da Campanha:{campaign.Name}");

        }
    }
}
