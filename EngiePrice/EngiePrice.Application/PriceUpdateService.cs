using EngiePrice.Domain.Entities;
using EngiePrice.Domain.Services;

namespace EngiePrice.Application;

public class PriceUpdateService
{
    private readonly PricePublisher _pricePublisher;

    public PriceUpdateService(PricePublisher pricePublisher)
    {
        _pricePublisher = pricePublisher;
    }

    public void StartPriceUpdates(Action<CurrencyPair> updatePrice)
    {
        _pricePublisher.StartPublishing(updatePrice);
    }
}
