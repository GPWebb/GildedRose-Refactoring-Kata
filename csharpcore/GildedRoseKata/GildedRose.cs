using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            UpdateItem(item);
        }
    }

    private void UpdateItem(Item item)
    {
        UpdateItemQuality(item);

        if (item.Name != Constants.Sulfuras) item.SellIn--;

        if (item.SellIn < Constants.SellInLow) UpdateItemBelowSellInLowQuality(item);
    }

    private static void UpdateItemQuality(Item item)
    {
        if (item.Name != Constants.AgedBrie && item.Name != Constants.BackstagePasses)
        {
            DropNonSulfurasQuality(item);
        }
        else
        {
            if (item.Quality < Constants.ItemQualityUpperThreshold)
            {
                item.Quality++;

                if (item.Name == Constants.BackstagePasses)
                {
                    UpdateBackstagePassItemQuality(item);
                }
            }
        }
    }

    private static void UpdateItemBelowSellInLowQuality(Item item)
    {
        if (item.Name != Constants.AgedBrie)
        {
            DropExpiringItemQuality(item);
        }
        else
        {
            if (item.Quality < Constants.ItemQualityUpperThreshold)
            {
                item.Quality++;
            }
        }
    }

    private static void DropExpiringItemQuality(Item item)
    {
        if (item.Name != Constants.BackstagePasses)
        {
            DropNonSulfurasQuality(item);
        }
        else
        {
            item.Quality = 0;
        }
    }

    private static void DropNonSulfurasQuality(Item item)
    {
        if (item.Quality > 0 && item.Name != Constants.Sulfuras)
        {
            item.Quality--;
        }
    }

    private static void UpdateBackstagePassItemQuality(Item item)
    {
        if (item.SellIn < Constants.SellInHigh)
        {
            if (item.Quality < Constants.ItemQualityUpperThreshold)
            {
                item.Quality++;
            }
        }

        if (item.SellIn < Constants.SellInMid)
        {
            if (item.Quality < Constants.ItemQualityUpperThreshold)
            {
                item.Quality++;
            }
        }
    }
}