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

    [SerializeField] private Sprite _spriteAfterUsingItem;

    [SerializeField] private Item givingItem;

    private GameObject draggableItem;

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
        draggableItem = DraggableContainer.DraggableItem;
        Debug.Log("DraggableItem: " + draggableItem);
    }

    public void OnItemDrop()
    {
        if (draggableItem != null)
        {
            Sprite draggableItemSprite = DraggableContainer.DraggableItem
                .GetComponent<Image>().sprite;
            Sprite requiredItemSprite = requiredItems[_currItemIndex]
                .GetComponent<SpriteRenderer>().sprite;

            if (requiredItemSprite == draggableItemSprite)
            {
                Debug.Log("Should remove the items");
                _inventory.RemoveItem(requiredItems[_currItemIndex]);
                if (_currItemIndex == _maxItemIndex)
                {
                    Inventory.AddItem(givingItem);
                    gameObject.SetActive(false);
                }
                _currItemIndex++;
                if (_spriteAfterUsingItem != null)
                {
                    GetComponent<SpriteRenderer>().sprite = _spriteAfterUsingItem;
                }
            }
            draggableItem = null;
        }

    }

}
