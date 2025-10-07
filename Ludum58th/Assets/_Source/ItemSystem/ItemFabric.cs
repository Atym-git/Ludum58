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

    public void InstantiateItems(ItemSO[] itemSOs, CoroutineRunner coroutineRunner)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            //Debug.Log("_itemRoots.Count" + _itemRoots.Count);
            //Debug.Log("itemSOs.Length" + itemSOs.Length);
            //Debug.Log("_itemRoots[i] " + _itemRoots[i] + " Index : " + i);
            if (i < _itemRoots.Count)
            {
                GameObject itemGO = Object.Instantiate(_itemPrefab, _itemRoots[i]);
                Item item = itemGO.GetComponent<Item>();

                ItemSO itemSO = itemSOs[i];
                item.Construct(itemSO.ItemSprite,
                               itemSO.ItemNotificationText,
                               itemSO.ItemNotificationDuration,
                               itemSO.ItemIconDisplayDuration,
                               itemSO.CouldBeInInventory,
                               itemSO.ItemPrefab,
                               coroutineRunner);

            }
        }
    }
}
