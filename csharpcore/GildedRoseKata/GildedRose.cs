using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;
    private readonly UpdateItem _updateItem;

    public GildedRose(IList<Item> items)
    {
        _items = items;

        //HACK Set up with proper DI
        _updateItem = new UpdateItem(
            new UpdateItemQuality(
                new DropNonSulfurasQuality(),
                new UpdateBackstagePassItemQuality(
                    new UpdateQualityByThresholds())),
            new UpdateItemBelowSellInLowQuality(
                new DropExpiringItemQuality(
                    new DropNonSulfurasQuality())));
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            _updateItem.Update(item);
        }
    }
}