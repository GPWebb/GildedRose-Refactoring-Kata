namespace GildedRoseKata
{
    public class DropNonSulfurasQuality : IDropNonSulfurasQuality
    {
        public void Drop(Item item)
        {
            if (item.Quality > 0 && item.Name != Constants.Sulfuras)
            {
                item.Quality--;
            }
        }
    }
}
