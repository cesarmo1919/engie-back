using System;
using EngiePrice.Domain.Entities;
using EngiePrice.Domain.Services;

namespace EngiePrice.Application;

public class PricePublisher
{
    private readonly PriceGenerator _priceGenerator = new PriceGenerator();
    private static Random _random = new Random();

    public async Task PublishPrice(CurrencyPair pair, Action<CurrencyPair> updatePrice)
    {
        while (true)
        {
            pair.UpdatePrice(_priceGenerator.GeneratePrice());
            updatePrice(pair);
            await Task.Delay(_random.Next(1, 100));
        }
    }

    public void StartPublishing(Action<CurrencyPair> updatePrice)
    {
        var pairs = new List<CurrencyPair>
            {
                new CurrencyPair("EUR/USD"),
                new CurrencyPair("EUR/GBP"),
                new CurrencyPair("USD/GBP")
            };

        var tasks = pairs.ConvertAll(pair => PublishPrice(pair, updatePrice));
        Task.WhenAll(tasks);
    }
}
