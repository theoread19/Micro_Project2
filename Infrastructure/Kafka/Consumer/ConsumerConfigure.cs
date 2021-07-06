using Confluent.Kafka;
using Domain.Models;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Kafka.Consumer
{
    public class ConsumerConfigure : BackgroundService
    {
        private readonly string _topic = "test1";

/*        public async Task StartAsync(CancellationToken cancellationToken)
        {
            
        }
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }*/

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var conf = new ConsumerConfig
            {
                GroupId = "st_consumer_group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false
            };

            using (var builder = new ConsumerBuilder<string, byte []>(conf).Build())
            {
                builder.Subscribe(this._topic);

                var cancelToken = new CancellationTokenSource();
                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        var consumer = builder.Consume(cancelToken.Token);

                        var data = consumer.Message.Value;
                        MemoryStream memStream = new MemoryStream();
                        BinaryFormatter binForm = new BinaryFormatter();
                        memStream.Write(data, 0, data.Length);
                        memStream.Seek(0, SeekOrigin.Begin);
                        var obj = (UserModel)binForm.Deserialize(memStream);
                        Console.WriteLine(obj.Fullname);
                        builder.Commit();
                        Console.WriteLine($"Message: {consumer.Message.Key} received from {consumer.TopicPartitionOffset} and data {System.Text.Encoding.UTF8.GetString(consumer.Message.Value)}");
                       
                        //await Task.Delay(1000);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error");
                        builder.Close();
                    }
                }
            }
            await Task.CompletedTask;
        }
    }
}
