using System.Collections;
using System.Collections.Generic;
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

    public void ShowItems(Item item, int rootIndex, TextMeshProUGUI inventoryNotifTMP, float notifDuration)
    {
        ShowInventory();

        if (_inventoryTransforms.Count > rootIndex)
        {
            item.SelfDestruct();

            _inventoryTransforms[rootIndex].gameObject.SetActive(true);
            _inventoryTransforms[rootIndex].GetComponent<Image>().sprite = item.ItemSprite;

            inventoryNotifTMP.text = item.ItemNotifText;

            _runner.RunCoroutine(Delay(notifDuration, inventoryNotifTMP.gameObject));
        }
        else
        {
            Debug.Log($"Not Enough Place for items; " +
                      $"_inventoryTransforms count = {_inventoryTransforms.Count}");
        }
    }

    private void ShowInventory()
    {
        if (!_inventoryTransformsParent.activeInHierarchy)
        {
            _inventoryTransformsParent.SetActive(true);
        }
    }

    private IEnumerator Delay(float seconds, GameObject inventoryNotifGO)
    {
        inventoryNotifGO.SetActive(true);
        yield return new WaitForSeconds(seconds);
        inventoryNotifGO.SetActive(false);
    }

}
