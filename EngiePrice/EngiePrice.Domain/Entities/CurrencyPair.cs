namespace EngiePrice.Domain.Entities;

public class CurrencyPair
{
    public string PairName { get; private set; }
    public decimal Price { get; private set; }

    public CurrencyPair(string pairName)
    {
        PairName = pairName;
    }

    public void UpdatePrice(decimal newPrice)
    {
        Price = newPrice;
    }
}
