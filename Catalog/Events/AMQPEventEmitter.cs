﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Models;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace Catalog.Events
{
    public class AMQPEventEmitter : IEventEmitter
    {
        private readonly ILogger logger;

        private AMQPOptions rabbitOptions;

        private ConnectionFactory connectionFactory;

        public AMQPEventEmitter(ILogger<AMQPEventEmitter> logger,
            AMQPOptions amqpOptions)
        {
            this.logger = logger;
            this.rabbitOptions = amqpOptions;

            connectionFactory = new ConnectionFactory();

            connectionFactory.UserName = rabbitOptions.Username;
            connectionFactory.Password = rabbitOptions.Password;
            connectionFactory.VirtualHost = rabbitOptions.VirtualHost;
            connectionFactory.HostName = rabbitOptions.HostName;
            connectionFactory.Uri = new Uri(rabbitOptions.Uri);//rabbitOptions.Uri;

            logger.LogInformation("AMQP Event Emitter configured with URI {0}", rabbitOptions.Uri);
        }
        public const string QUEUE_NEWPRODUCT = "newproductadded";


        public void EmitProductAddedEvent(NewProductEvent newProductEvent)
        {
            using (IConnection conn = connectionFactory.CreateConnection())
            {
                using (IModel channel = conn.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: QUEUE_NEWPRODUCT,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );
                    string jsonPayload = newProductEvent.toJson();
                    var body = Encoding.UTF8.GetBytes(jsonPayload);
                    channel.BasicPublish(
                        exchange: "",
                        routingKey: QUEUE_NEWPRODUCT,
                        basicProperties: null,
                        body: body
                    );
                }
            }
        }
    }
}
