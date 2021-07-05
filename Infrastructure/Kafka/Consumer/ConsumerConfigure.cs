using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Kafka.Consumer
{
    public class ConsumerConfigure : IHostedService
    {
        private readonly string _topic = "test";

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var conf = new ConsumerConfig
            {
                GroupId = "st_consumer_group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var builder = new ConsumerBuilder<string,string>(conf).Build())
            {
                builder.Subscribe(this._topic);
                
                var cancelToken = new CancellationTokenSource();
                try
                {
/*                    while (true)
                    {*/
                        var consumer = builder.Consume(cancelToken.Token);
                    
                        Console.WriteLine($"Message: {consumer.Message.Value} received from {consumer.TopicPartitionOffset}");
                        
                    //}
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                    //builder.Close();
                }
            }
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
