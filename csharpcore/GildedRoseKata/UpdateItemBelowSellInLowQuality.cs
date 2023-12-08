namespace GildedRoseKata
{
    public class UpdateItemBelowSellInLowQuality : IUpdateItemBelowSellInLowQuality
    {
        private readonly IDropExpiringItemQuality _dropExpiringItemQuality;

        public UpdateItemBelowSellInLowQuality(IDropExpiringItemQuality dropExpiringItemQuality)
        {
            _dropExpiringItemQuality = dropExpiringItemQuality;
        }

        public void Update(Item item)
        {
            if (item.Name != Constants.AgedBrie)
            {
                _dropExpiringItemQuality.Drop(item);
            }
            else if (item.Quality < Constants.ItemQualityUpperThreshold)
            {
                item.Quality++;
            }
        }
    }
}
