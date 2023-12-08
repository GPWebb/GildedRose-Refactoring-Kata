namespace GildedRoseKata
{
    public class UpdateItem : IUpdateItem
    {
        private readonly IUpdateItemQuality _updateItemQuality;
        private readonly IUpdateItemBelowSellInLowQuality _updateItemBelowSellInLowQuality;

        public UpdateItem(IUpdateItemQuality updateItemQuality,
            IUpdateItemBelowSellInLowQuality updateItemBelowSellInLowQuality)
        {
            _updateItemQuality = updateItemQuality;
            _updateItemBelowSellInLowQuality = updateItemBelowSellInLowQuality;
        }

        public void Update(Item item)
        {
            _updateItemQuality.Update(item);

            if (item.Name != Constants.Sulfuras) item.SellIn--;

            if (item.SellIn < Constants.SellInLow) _updateItemBelowSellInLowQuality.Update(item);
        }
    }
}
