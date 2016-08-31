﻿using NServiceBus;

namespace FireOnWheels.Messages
{
    public interface IOrderActivityEvent: IEvent
    {
        string AddressFrom { get; set; }
        string AddressTo { get; set; }
        int Weight { get; set; }
        int Price { get; set; } 
    }
}