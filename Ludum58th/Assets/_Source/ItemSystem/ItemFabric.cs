using System.Collections.Generic;
using UnityEngine;

public class ItemFabric
{
    private GameObject _itemPrefab;
    private List<Transform> _itemRoots;

    private GameObject _inventoryNotifPanel;

    public ItemFabric(GameObject itemPrefab, List<Transform> itemRoots, GameObject inventoryNotifPanel)
    {
        _itemPrefab = itemPrefab;
        _itemRoots = itemRoots;
        _inventoryNotifPanel = inventoryNotifPanel;
    }

    public void InstantiateItems(ItemSO[] itemSOs, CoroutineRunner coroutineRunner)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
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
                               _inventoryNotifPanel,
                               itemSO.MoveTowardsXAfterPress,
                               coroutineRunner);

            }
        }
    }
}
