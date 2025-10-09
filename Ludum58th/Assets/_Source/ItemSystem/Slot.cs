using System;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField] private bool isPhotoChanger = false;

    [SerializeField] private GameObject photoPanel;

    [SerializeField] private Image photoPartImage;
    [SerializeField] private Sprite photoPartDoneSprite;

    [SerializeField] private List<Slot> slots = new();

    [field:SerializeField] public bool IsPartDone { get; private set; }

    [SerializeField] private TextMeshProUGUI itemsLeftTMP;

    private IsPhotoDone _isPhotoDone;

    [SerializeField] private GameObject helpingSpriteGO;

    public void Construct(Inventory inventory, IsPhotoDone isPhotoDone)
    {
        _inventory = inventory;
        _isPhotoDone = isPhotoDone;
    }

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        GetMaxReqItemIndex();

        GetRequiredItems();
        GetGivingItems();
        if (isPhotoChanger && slots.Count == 0)
        {
            slots.Add(this);
        }
    }

    private void GetMaxReqItemIndex()
    {
        if (requiredItemsParents.Count > 0)
        {
            _maxRequiredItemIndex = requiredItemsParents.Count - 1;
        }
        else
        {
            _maxRequiredItemIndex = requiredItems.Count - 1;
        }
    }

    private void GetRequiredItems()
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
    }

    private void GetGivingItems()
    {
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
                    if (isPhotoChanger)
                    {
                        IsPartDone = true;

                        if (helpingSpriteGO != null)
                        {
                            helpingSpriteGO.SetActive(false);
                        }

                        GameObject itemPrefab = transform.GetChild(0).gameObject;
                        itemPrefab.SetActive(true);

                        if (_isPhotoDone.IsPartDone(slots))
                        {
                            _isPhotoDone.CheckFullPhoto();
                            photoPanel.SetActive(true);
                            ChangePhotoPart(photoPartImage, photoPartDoneSprite);
                        }
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

            ShowLeftItemsUI();
        }

    }

    public void ShowLeftItemsUI()
    {
        if (itemsLeftTMP != null)
        {
            int itemsLeft = requiredItems.Count - _currRequiredItemIndex;
            itemsLeftTMP.text = itemsLeft.ToString();
            itemsLeftTMP.gameObject.SetActive(itemsLeft != 0);
        }
    }

    private void ChangePhotoPart(Image partImage, Sprite photoPartDoneSprite)
    {
        partImage.sprite = photoPartDoneSprite;
    }
}
