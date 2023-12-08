namespace GildedRoseKata
{
    public class UpdateBackstagePassItemQuality : IUpdateBackstagePassItemQuality
    {
        private readonly IUpdateQualityByThresholds _updateQualityByThresholds;

        public UpdateBackstagePassItemQuality(IUpdateQualityByThresholds updateQualityByThresholds)
        {
            _updateQualityByThresholds = updateQualityByThresholds;
        }

        public void Update(Item item)
        {
            _updateQualityByThresholds.Update(item, Constants.SellInHigh, Constants.ItemQualityUpperThreshold);
            _updateQualityByThresholds.Update(item, Constants.SellInMid, Constants.ItemQualityUpperThreshold);
        }
    }
}
