using GildedRoseKata;
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
        for (var i = 0; i < _items.Count; i++)
        {
            UpdateItem(_items[i]);
        }
    }

    private void UpdateItem(Item item)
    {
        if (item.Name != Constants.AgedBrie && item.Name != Constants.BackstagePasses)
        {
            if (item.Quality > 0)
            {
                if (item.Name != Constants.Sulfuras)
                {
                    item.Quality--;
                }
            }
        }
        else
        {
            if (item.Quality < Constants.ItemQualityUpperThreshold)
            {
                item.Quality++;

                if (item.Name == Constants.BackstagePasses)
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
        }

        if (item.Name != Constants.Sulfuras)
        {
            item.SellIn--;
        }

        if (item.SellIn < Constants.SellInLow)
        {
            if (item.Name != Constants.AgedBrie)
            {
                if (item.Name != Constants.BackstagePasses)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != Constants.Sulfuras)
                        {
                            item.Quality--;
                        }
                    }
                }
                else
                {
                    item.Quality = 0;
                }
            }
            else
            {
                if (item.Quality < Constants.ItemQualityUpperThreshold)
                {
                    item.Quality++;
                }
            }
        }
    }
}