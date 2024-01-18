﻿using Confluent.Kafka;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Text.Json;

namespace Licenta.UI.Services
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly LicentaConfig _licentaConfig;
        private readonly IProducer<string, string> _producer;

        public KafkaProducer(LicentaConfig licentaConfig)
        {
            _licentaConfig = licentaConfig;
            var configProducer = new ProducerConfig
            {
                BootstrapServers = _licentaConfig.Kafka.Address,
                SecurityProtocol = SecurityProtocol.Plaintext
            };

            _producer = new ProducerBuilder<string, string>(configProducer).Build();
        }


        public async Task ProduceAsync(string topicName, string key, object value)
        {
            string str = JsonSerializer.Serialize(value);
            KafkaDto kafkaDto = new KafkaDto("", key, str);
            string transferObject = JsonSerializer.Serialize(kafkaDto);
            try
            {
                await _producer.ProduceAsync(topicName, new Message<string, string>
                {
                    Key = key,
                    Value = transferObject
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}