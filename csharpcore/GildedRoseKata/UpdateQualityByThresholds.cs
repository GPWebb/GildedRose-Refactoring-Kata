namespace GildedRoseKata
{
    public class UpdateQualityByThresholds : IUpdateQualityByThresholds
    {
        public void Update(Item item, int sellInThreshold, int qualityThreshold)
        {
            if (item.SellIn < sellInThreshold && item.Quality < qualityThreshold)
            {
                item.Quality++;
            }
        }
    }
}
