﻿using Licenta.Sdk.Models.Dtos;

namespace Licenta.DataAccessService.Interfaces
{
    public interface IEbusListener
    {
        void Subscribe(string sessionId, Func<KafkaResult, Task> notifyResponse);
        void UnSubscribe(string sessionId);
    }
}