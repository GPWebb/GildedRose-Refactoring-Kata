namespace GildedRoseKata
{
    public interface IUpdateQualityByThresholds
    {
        void Update(Item item, int sellInThreshold, int qualityThreshold);
    }
}