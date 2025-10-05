using System.Collections.Generic;
using UnityEngine;

public class ItemFabric
{
    private GameObject _itemPrefab;
    private List<Transform> _itemRoots;

    public ItemFabric(GameObject itemPrefab, List<Transform> itemRoots)
    {
        _itemPrefab = itemPrefab;
        _itemRoots = itemRoots;
    }

    public void InstantiateItems(ItemSO[] itemSOs)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (_itemRoots[i] != null)
            {
                GameObject itemGO = Object.Instantiate(_itemPrefab, _itemRoots[i]);
                Item item = itemGO.GetComponent<Item>();

                ItemSO itemSO = itemSOs[i];
                item.Construct(itemSO.ItemSprite,
                               itemSO.ItemNotificationText,
                               itemSO.ItemNotificationDuration);

            }
        }
    }
}
