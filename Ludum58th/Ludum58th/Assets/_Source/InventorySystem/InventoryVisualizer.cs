using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryVisualizer
{
    private List<Transform> _inventoryTransforms = new();
    private GameObject _inventoryTransformsParent;

    private CoroutineRunner _runner;

    public InventoryVisualizer(Transform inventoryTransformsParent, CoroutineRunner coroutineRunner)
    {
        _inventoryTransformsParent = inventoryTransformsParent.gameObject;
        _runner = coroutineRunner;

        GetInventoryTransforms(inventoryTransformsParent);
    }

    private void GetInventoryTransforms(Transform inventoryTransformsParent)
    {
        for (int i = 0; i < inventoryTransformsParent.childCount; i++)
        {
            Transform child = inventoryTransformsParent.GetChild(i);

            if (child.childCount > 0)
            {
                int singleChild = 0;
                _inventoryTransforms.Add(child.GetChild(singleChild));
            }

        }
    }

    public void ShowItems(Item item, int rootIndex)
    {
        ShowInventory();

        if (_inventoryTransforms.Count > rootIndex)
        {
            //item.SelfDestruct();
            item.DisableItem();

            Image inventoryItemImage = _inventoryTransforms[rootIndex].GetComponent<Image>();

            inventoryItemImage.enabled = true;
            inventoryItemImage.sprite = item.ItemSprite;
        }
        else
        {
            Transform newInventorySlot = Object.Instantiate(_inventoryTransforms[rootIndex - 1].parent, _inventoryTransformsParent.transform);
            _inventoryTransforms.Add(newInventorySlot.GetChild(0));
            ShowItems(item, rootIndex);
        }
    }

    public void RemapItemsPlaces(List<Item> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            Image inventoryItemImage = _inventoryTransforms[i].GetComponent<Image>();
            inventoryItemImage.sprite = items[i].ItemSprite;
            inventoryItemImage.enabled = true;
        }
        for (int i = items.Count; i < _inventoryTransforms.Count; i++)
        {
            _inventoryTransforms[i].GetComponent<Image>().enabled = false;
        }
    }

    private void ShowInventory()
    {
        if (!_inventoryTransformsParent.activeInHierarchy)
        {
            _inventoryTransformsParent.SetActive(true);
        }
    }

}
