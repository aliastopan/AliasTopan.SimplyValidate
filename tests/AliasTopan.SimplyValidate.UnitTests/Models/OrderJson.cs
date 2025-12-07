using AliasTopan.SimplyValidate.DataAnnotations;

namespace AliasTopan.SimplyValidate.UnitTests.Models;

public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

public sealed class OrderJson
{
    [ParsableEnum(typeof(OrderStatus))]
    public string OrderStatus { get; set; } = default!;
}

