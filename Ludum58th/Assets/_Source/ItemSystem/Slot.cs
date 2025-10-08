using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
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
    [SerializeField] private Transform givingItemParentTransform;

    private GameObject _draggableItem;

    private BoxCollider _boxCollider;

    public void Construct(/*DraggableContainer container,*/ Inventory inventory)
    {
        //_draggableContainer = container;
        _inventory = inventory;
    }

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _maxItemIndex = requiredItemsParents.Count - 1;
        GetItems();
    }

    private void GetItems()
    {
        if (requiredItemsParents.Count > 0)
        {
            for (int i = 0; i < requiredItemsParents.Count; i++)
            {
                if (requiredItemsParents[i].childCount > 0)
                {
                    requiredItems.Add(requiredItemsParents[i]
                        .GetComponentInChildren<Item>());
                }
            }
        }
        if (givingItem == null && givingItemParentTransform != null)
        {
            givingItem = givingItemParentTransform.GetComponentInChildren<Item>();
        }
    }


    private void FixedUpdate()
    {
        _boxCollider.enabled = DraggableContainer.IsDragging;      
    }

    private void OnMouseEnter()
    {
        _draggableItem = DraggableContainer.DraggableItem;

    }

    public void OnItemDrop()
    {
        if (_draggableItem != null)
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
                    if (givingItem.ItemPrefab != null)
                    {
                        givingItem.CouldBeInventory();
                    }
                    else
                    {
                        Inventory.AddItem(givingItem);
                    }
                    //gameObject.SetActive(false);
                }
                _currItemIndex++;
                if (_spriteAfterUsingItem != null)
                {
                    GetComponent<SpriteRenderer>().sprite = _spriteAfterUsingItem;
                }
            }
            _draggableItem = null;
            if (transform.TryGetComponent(out _boxCollider))
            {
                DraggableContainer.IsDragging = false;
                _boxCollider.enabled = DraggableContainer.IsDragging;
            }
        }

    }

}
