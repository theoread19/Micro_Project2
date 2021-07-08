using Confluent.Kafka;
using Infrastructure.Repository;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserProtoBufService;

namespace Infrastructure.Kafka.Consumer
{
    public class ConsumerConfigure : BackgroundService
    {
        private readonly string _topic = "test5";

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var conf = new ConsumerConfig
            {
                GroupId = "st_consumer_group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false
            };


            using (var builder = new ConsumerBuilder<string, UserProtoReq>(conf)
                .SetValueDeserializer(new UserDeserializer())
                .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}"))
                .Build())
            {
                builder.Subscribe(this._topic);

                var cancelToken = new CancellationTokenSource();
                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        Console.WriteLine("Starting consume");
                        // builder.Consume return null and project can't load swagger api if there is no message
                        // waiting for consume when run project 
                        var consumer = builder.Consume(cancelToken.Token);
                        Console.WriteLine("bb");
                        var data = consumer.Message.Value;
                        if (data != null)
                        {
                            var handle = new HandleConsumer(new UserRepository());
                            handle.Handle(data);
                        }

                        builder.Commit();
                        Console.WriteLine($"Message: received from {consumer.TopicPartitionOffset} and data");

                        await Task.Delay(1000);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error:" + e );
                        builder.Close();
                        await Task.CompletedTask;
                    }
                }
                
            }
        }
    }
}
