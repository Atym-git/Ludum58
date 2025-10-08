using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class Slot : MonoBehaviour/*, IDropHandler*/
{
    [field: Header("Required items")]
    [SerializeField] private List<Transform> requiredItemsParents = new();
    [SerializeField] private List<Item> requiredItems = new();

    private Inventory _inventory;

    private int _maxRequiredItemIndex = 0;
    private int _currRequiredItemIndex = 0;

    [field:Header("Item after all items were gotten")]

    [SerializeField] private Item givingItem;
    [SerializeField] private Transform givingItemParentTransform;

    private GameObject _draggableItem;

    private BoxCollider _boxCollider;

    [field: Header("Photo Related")]

    [SerializeField] private bool _isPhotoChanger = false;

    [SerializeField] private GameObject _photoPanel;

    [SerializeField] private Image _photoPartImage;
    [SerializeField] private Sprite _photoPartDoneSprite;

    [SerializeField] private List<Slot> _slots = new();

    [field:SerializeField] public bool IsPartDone { get; private set; }
    [SerializeField] private int _itemsDone = 0;

    public void Construct(Inventory inventory)
    {
        _inventory = inventory;
    }

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        if (requiredItemsParents.Count > 0)
        {
            _maxRequiredItemIndex = requiredItemsParents.Count - 1;
        }
        else
        {
            _maxRequiredItemIndex = requiredItems.Count - 1;
        }
        
        GetItems();
        if (_isPhotoChanger && _slots.Count == 0)
        {
            _slots.Add(this);
        }
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
            Sprite requiredItemSprite = requiredItems[_currRequiredItemIndex]
                .GetComponent<SpriteRenderer>().sprite;

            if (requiredItemSprite == draggableItemSprite)
            {
                _inventory.RemoveItem(requiredItems[_currRequiredItemIndex]);
                if (_currRequiredItemIndex == _maxRequiredItemIndex)
                {
                    if (_isPhotoChanger)
                    {
                        IsPartDone = true;
                        
                        for (int i = 0; i < _slots.Count; i++)
                        {
                            _itemsDone += Convert.ToInt32(_slots[i].IsPartDone);
                            if (_itemsDone == _slots.Count)
                            {
                                _photoPanel.SetActive(true);
                                ChangePhotoPart(_photoPartImage, _photoPartDoneSprite);
                                GameObject itemPrefab = transform.GetChild(0).gameObject;
                                itemPrefab.SetActive(true);
                            }
                        }
                        _itemsDone = 0;
                    }
                    else if (givingItem.ItemPrefab != null)
                    {
                        givingItem.CouldBeInventory();
                    }
                    else if (givingItem.ItemPrefab == null)
                    {
                        Inventory.AddItem(givingItem);
                    }
                }
                _currRequiredItemIndex++;
            }
            _draggableItem = null;
            if (transform.TryGetComponent(out _boxCollider))
            {
                DraggableContainer.IsDragging = false;
                _boxCollider.enabled = DraggableContainer.IsDragging;
            }
        }

    }

    private void ChangePhotoPart(Image partImage, Sprite photoPartDoneSprite)
    {
        partImage.sprite = photoPartDoneSprite;
    }
}
