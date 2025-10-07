using System.Linq;
using UnityEngine;

public class ResourceLoader
{
    public ItemSO[] LoadItemsSO()
    {
        ItemSO[] itemSOs = Resources.LoadAll("SO/Items", typeof(ItemSO))
            .Cast<ItemSO>()
            .ToArray();
        //Assets/_Presentation/Resources/SO/Items/ZzakolkaSO42.asset
        return itemSOs;
    }
}
