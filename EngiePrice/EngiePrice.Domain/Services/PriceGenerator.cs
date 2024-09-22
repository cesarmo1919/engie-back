using System;

namespace EngiePrice.Domain.Services;

public class PriceGenerator
{
    private static Random _random = new Random();

    public decimal GeneratePrice()
    {
        return (decimal)(_random.NextDouble() * (1.5 - 0.5) + 0.5);
    }
}
