using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

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

    public void ShowItems(Item item, int rootIndex, TextMeshProUGUI inventoryNotifTMP, float notifDuration)
    {
        ShowInventory();

        if (_inventoryTransforms.Count > rootIndex)
        {
            //item.SelfDestruct();
            item.DisableItem();

            Image inventoryItemImage = _inventoryTransforms[rootIndex].GetComponent<Image>();

            //_inventoryTransforms[rootIndex].gameObject.SetActive(true);
            inventoryItemImage.enabled = true;
            inventoryItemImage.sprite = item.ItemSprite;

            //inventoryNotifTMP.text = item.ItemNotifText;

            //_runner.RunCoroutine(Delay(notifDuration, inventoryNotifTMP.gameObject));
        }
        else
        {
            Debug.Log($"Not Enough Place for items; " +
                      $"_inventoryTransforms count = {_inventoryTransforms.Count}");
        }
    }

    public void StopShowingItems(int rootIndex)
    {
        Debug.Log("Root Index: " + rootIndex);
        //_inventoryTransforms[rootIndex].gameObject.activeInHierarchy = false;
        //_inventoryTransforms[rootIndex].gameObject.SetActive(false);
        Transform inventoryTransform = _inventoryTransforms[rootIndex];
        inventoryTransform.GetComponent<Image>().enabled = false;
        inventoryTransform.SetAsLastSibling();
        _inventoryTransforms.RemoveAt(rootIndex);
        _inventoryTransforms.Add(inventoryTransform);
        //_inventoryTransforms[rootIndex].GetComponent<Image>().sprite = null;
    }

    private void ShowInventory()
    {
        if (!_inventoryTransformsParent.activeInHierarchy)
        {
            _inventoryTransformsParent.SetActive(true);
        }
    }



}
