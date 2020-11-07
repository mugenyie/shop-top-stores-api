using System;
using System.Collections.Generic;
using System.Text;

namespace catalina.Repositories.Enums
{
    public enum OrderStatus
    {
        PROCESSING,
        PENDING_PAYMENT,
        PAYMENT_RECEIVED,
        IN_TRANSIT,
        DELIVERED,
        CANCELED,
        REFUNDED
    }
}
