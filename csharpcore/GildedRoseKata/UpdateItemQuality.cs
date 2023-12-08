namespace GildedRoseKata
{
    public class UpdateItemQuality : IUpdateItemQuality
    {
        private readonly IDropNonSulfurasQuality _dropNonSulfurasQuality;
        private readonly IUpdateBackstagePassItemQuality _updateBackstagePassItemQuality;

        public UpdateItemQuality(IDropNonSulfurasQuality dropNonSulfurasQuality,
            IUpdateBackstagePassItemQuality updateBackstagePassItemQuality)
        {
            _dropNonSulfurasQuality = dropNonSulfurasQuality;
            _updateBackstagePassItemQuality = updateBackstagePassItemQuality;
        }

        public void Update(Item item)
        {
            if (item.Name != Constants.AgedBrie && item.Name != Constants.BackstagePasses)
            {
                _dropNonSulfurasQuality.Drop(item);
            }
            else if (item.Quality < Constants.ItemQualityUpperThreshold)
            {
                item.Quality++;

                if (item.Name == Constants.BackstagePasses)
                {
                    _updateBackstagePassItemQuality.Update(item);
                }
            }
        }
    }
}
