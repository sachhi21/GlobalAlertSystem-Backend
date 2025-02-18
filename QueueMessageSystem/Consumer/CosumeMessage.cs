using Confluent.Kafka;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace QueueMessageSystem.Consumer
{
    public class ConsumeMessage
    {
        private readonly string _bootstrapServers;

        public ConsumeMessage(string bootstrapServers)
        {
            _bootstrapServers = bootstrapServers;
        }

        public void ConsumeAndRoute(string[] topics)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _bootstrapServers,
                GroupId = "my-group",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false,
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Subscribe(topics);

                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cts.Cancel();
                };

                try
                {
                    while (!cts.Token.IsCancellationRequested)
                    {
                        try
                        {
                            var consumeResult = consumer.Consume(cts.Token);

                            Console.WriteLine($"Consumed message from topic {consumeResult.Topic}: {consumeResult.Message.Value}");

                            // Route the message to the corresponding microservice
                            RouteMessage(consumeResult.Topic, consumeResult.Message.Value);

                            // Commit offset manually after successful processing
                            consumer.Commit(consumeResult);
                        }
                        catch (ConsumeException ex)
                        {
                            Console.WriteLine($"Error consuming message: {ex.Error.Reason}");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Consumer operation was canceled.");
                }
                finally
                {
                    consumer.Close();
                }
            }
        }

        private void RouteMessage(string topic, string message)
        {
            string microserviceUrl = topic switch
            {
                "topic1" => "http://microservice1/api/endpoint",
                "topic2" => "http://microservice2/api/endpoint",
                "topic3" => "http://microservice3/api/endpoint",
                _ => null
            };

            if (microserviceUrl != null)
            {
                SendToMicroservice(microserviceUrl, message);
            }
            else
            {
                Console.WriteLine($"No microservice defined for topic: {topic}");
            }
        }

        private async void SendToMicroservice(string url, string message)
        {
            using var httpClient = new HttpClient();
            var content = new StringContent(message, Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Message successfully sent to {url}");
                }
                else
                {
                    Console.WriteLine($"Failed to send message to {url}. Status: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message to {url}: {ex.Message}");
            }
        }
    }
}
