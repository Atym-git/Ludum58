using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryVisualizer
{
    private List<Transform> _inventoryTransforms = new();
    private GameObject _inventoryTransformsParent;

    public InventoryVisualizer(Transform inventoryTransformsParent)
    {
        GetInventoryTransforms(inventoryTransformsParent);
    }

    private void GetInventoryTransforms(Transform inventoryTransformsParent)
    {
        _inventoryTransformsParent = inventoryTransformsParent.gameObject;

        for (int i = 0; i < inventoryTransformsParent.childCount; i++)
        {
            //if (inventoryTransformsParent.GetChild(i) != null)
            //{
                Debug.Log($"Parent child count: {inventoryTransformsParent.childCount}");
                Debug.Log($"Child Index: {i}");
                Transform child = inventoryTransformsParent.GetChild(i);

                if (child.childCount > 0)
                {
                    _inventoryTransforms.Add(child.GetChild(0));
                }
            //}
            
        }
        Debug.Log("Inventory transforms count = " + _inventoryTransforms.Count);
    }

    public void ShowInventoryItems(Sprite itemSprite, int rootIndex)
    {
        _inventoryTransformsParent.SetActive(true);
        if (_inventoryTransforms[rootIndex] != null)
        {
            _inventoryTransforms[rootIndex].gameObject.SetActive(true);
            _inventoryTransforms[rootIndex].GetComponent<Image>().sprite = itemSprite;
        }
        else
        {
            Debug.Log("Not Enough Place");
        }
    }
}
