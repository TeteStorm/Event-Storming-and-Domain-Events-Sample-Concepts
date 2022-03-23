﻿using OrderMS.Data.EventStore;
using EventStore.ClientAPI;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderMS.Infrastructure.Behaviours
{
    public class EventLoggerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
        where TResponse : notnull
    {
        private readonly IEventStoreDbContext _eventStoreDbContext;

        public EventLoggerBehavior(IEventStoreDbContext eventStoreDbContext)
        {
            _eventStoreDbContext = eventStoreDbContext;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = await next();

            var requestName = request.ToString();

            // Commands convention
            if (requestName is not null && requestName.EndsWith("Command"))
            {
                Type requestType = request.GetType();
                string commandName = requestType.Name;

                var data = new Dictionary<string, object>
                {
                    {
                        "request", request
                    },
                    {
                        "response", response
                    }
                };

                string jsonData = JsonConvert.SerializeObject(data);
                byte[] dataBytes = Encoding.UTF8.GetBytes(jsonData);

                EventData eventData = new(eventId: Guid.NewGuid(),
                    type: commandName,
                    isJson: true,
                    data: dataBytes,
                    metadata: null);

                await _eventStoreDbContext.AppendToStreamAsync(eventData);
            }

            return response;
        }
    }
}