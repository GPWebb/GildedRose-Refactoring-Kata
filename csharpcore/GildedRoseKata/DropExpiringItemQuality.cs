namespace GildedRoseKata;

public class DropExpiringItemQuality : IDropExpiringItemQuality
{
    private readonly IDropNonSulfurasQuality _dropNonSulfurasQuality;

    public DropExpiringItemQuality(IDropNonSulfurasQuality dropNonSulfurasQuality)
    {
        _dropNonSulfurasQuality = dropNonSulfurasQuality;
    }

    public void Drop(Item item)
    {
        //If this gets more complex, refactor to strategies
        if (item.Name != Constants.BackstagePasses)
        {
            _dropNonSulfurasQuality.Drop(item);
        }
        else
        {
            item.Quality = 0;
        }
    }
}