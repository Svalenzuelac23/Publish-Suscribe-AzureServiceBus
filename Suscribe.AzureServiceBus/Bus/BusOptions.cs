using System;
using System.Collections.Generic;
using System.Text;

namespace Suscribe.AzureServiceBus.Bus
{
    public class BusOptions
    {
        public string Cn { get; set; }
        public string Topic { get; set; }
        public string Subscription { get; set; }
        public string SubscriptionErrors { get; set; }
    }
}
