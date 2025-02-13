using Confluent.Kafka;
using System;

namespace QueueMessageSystem.Producer
{
    public class SendMessage
    {
        private readonly string _bootstrapServers;

        public SendMessage(string bootstrapServers)
        {
            _bootstrapServers = bootstrapServers;
        }

        public void ProduceMessage(string topic, string key, string value)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = _bootstrapServers,
                Acks = Acks.All,
                MessageTimeoutMs = 5000,
                CompressionType = CompressionType.Gzip
            };

            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                try
                {
                    var result = producer.ProduceAsync(topic, new Message<string, string> { Key = key, Value = value }).GetAwaiter().GetResult();
                    Console.WriteLine($"Produced message to {result.TopicPartitionOffset}: key = {key}, value = {value}");
                }
                catch (ProduceException<string, string> ex)
                {
                    Console.WriteLine($"Failed to produce message: {ex.Error.Reason}");
                }
                catch(OperationCanceledException ex)
                {
                    Console.WriteLine($"Operation was cancelled: {ex.Message}");
                }
            }
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        const string topic = "purchases";

    //        string[] users = { "eabara", "jsmith", "sgarcia", "jbernard", "htanaka", "awalther" };
    //        string[] items = { "book", "alarm clock", "t-shirts", "gift card", "batteries" };

    //        var sendMessage = new SendMessage("localhost:9092"); // Replace with your Kafka broker address
    //        Random rnd = new Random();
    //        const int numMessages = 10;

    //        for (int i = 0; i < numMessages; ++i)
    //        {
    //            var user = users[rnd.Next(users.Length)];
    //            var item = items[rnd.Next(items.Length)];
    //            sendMessage.ProduceMessage(topic, user, item);
    //        }

    //        Console.WriteLine($"Finished producing {numMessages} messages to topic {topic}");
    //    }
    //}
}
