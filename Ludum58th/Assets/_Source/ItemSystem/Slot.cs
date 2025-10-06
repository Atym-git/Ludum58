using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour/*, IDropHandler*/
{
    [SerializeField] private List<Transform> requiredItemsParents = new();
    [SerializeField] private List<Item> requiredItems = new();

    private DraggableContainer _draggableContainer;
    private Inventory _inventory;

    private int _maxItemIndex = 0;
    private int _currItemIndex = 0;

    [SerializeField] private Item givingItem;

    public void Construct(/*DraggableContainer container,*/ Inventory inventory)
    {
        //_draggableContainer = container;
        _inventory = inventory;
    }

    private void Start()
    {
        _maxItemIndex = requiredItemsParents.Count - 1;
        for (int i = 0; i < requiredItemsParents.Count; i++)
        {
            if (requiredItemsParents[i].childCount > 0)
            {
                requiredItems.Add(requiredItemsParents[i]
                    .GetComponentInChildren<Item>());
            }
        }

    }

    private void OnMouseEnter()
    {
        Debug.Log("CurrItemIndex = " + _currItemIndex);

        if (DraggableContainer.DraggableItem != null)
        {
            Sprite draggableItemSprite = DraggableContainer.DraggableItem
                .GetComponent<Image>().sprite;
            Sprite requiredItemSprite = requiredItems[_currItemIndex]
                .GetComponent<SpriteRenderer>().sprite;

            if (requiredItemSprite == draggableItemSprite)
            {
                _inventory.RemoveItem(requiredItems[_currItemIndex]);
                if (_currItemIndex == _maxItemIndex)
                {
                    //Give another item
                    //Destroy(gameObject);
                    Inventory.AddItem(givingItem);
                    gameObject.SetActive(false);
                }
                _currItemIndex++;
            }
        }
    }
}
