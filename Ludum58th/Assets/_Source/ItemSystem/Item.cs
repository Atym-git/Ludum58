using TMPro;
using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    private static float ITEM_MOVING_SPEED = 0.03f;

    [field: SerializeField]
    public Sprite ItemSprite { get; private set; }

    public GameObject ItemPrefab {  get; private set; }

    [field: SerializeField]
    public float NotificationDuration { get; private set; }

    [SerializeField] public string _itemNotifText;

    private float _itemIconDisplayDuration;

    private bool _couldBeInInventory;
    private bool _readyToMove;

    [SerializeField] private float _moveTowardsXAfterPress;

    [SerializeField] private GameObject _inventoryNotifPanel;

    private TextMeshProUGUI _inventoryNotifTMP;

    [SerializeField] private CoroutineRunner _coroutineRunner;

    public void Construct(Sprite itemSprite,
                          string itemNotifText,
                          float itemNotifDuration,
                          float itemIconDisplayDuration,
                          bool couldBeInInventory,
                          GameObject itemPrefab,
                          GameObject inventoryNotifPanel,
                          float moveTowardsXAfterPress,
                          CoroutineRunner coroutineRunner)
    {
        ItemSprite = itemSprite;
        _itemNotifText = itemNotifText;
        NotificationDuration = itemNotifDuration;
        _couldBeInInventory = couldBeInInventory;
        ItemPrefab = itemPrefab;
        _inventoryNotifPanel = inventoryNotifPanel;
        _moveTowardsXAfterPress = transform.position.x + moveTowardsXAfterPress;
        _coroutineRunner = coroutineRunner;

        GetComponent<SpriteRenderer>().sprite = itemSprite;
    }

    private void Start()
    {
        if (ItemPrefab != null)
        {
            GameObject itemInstance3D = Instantiate(ItemPrefab, transform);
            itemInstance3D.SetActive(true);
        }

        if (_inventoryNotifPanel != null)
        {
            for (int i = 0; i < _inventoryNotifPanel.transform.childCount; i++)
            {
                Transform panelChild = _inventoryNotifPanel.transform.GetChild(i);
                if (panelChild.TryGetComponent(out TextMeshProUGUI invNotifTMP))
                {
                    _inventoryNotifTMP = invNotifTMP;
                }
            }
        }

    }

    private void FixedUpdate()
    {
        if (_readyToMove && transform.position.x < _moveTowardsXAfterPress)
        {
            Vector3 moveTo = transform.position + transform.right;
            transform.position = Vector3.MoveTowards(transform.position, moveTo, ITEM_MOVING_SPEED);
        }

    }

    public void OnClick()
    {
        Item item = gameObject.GetComponent<Item>();
        if (_couldBeInInventory)
        {
            Inventory.AddItem(item);
        }

        _readyToMove = true;
        ShowItemNotifText(item._itemNotifText);     
    }

    public void ShowItemNotifText(string notificationText)
    {
        _inventoryNotifTMP.text = notificationText;
        _coroutineRunner.RunCoroutine(NotifyDuration(NotificationDuration, _inventoryNotifPanel));
    }

    public void DisableItem() => gameObject.SetActive(false);

    private IEnumerator NotifyDuration(float seconds, GameObject inventoryNotifGO)
    {
        DraggableContainer.ItemsWhichDurDidntPass++;
        inventoryNotifGO.SetActive(true);
        yield return new WaitForSeconds(seconds);
        DraggableContainer.ItemsWhichDurDidntPass--;

        if (DraggableContainer.ItemsWhichDurDidntPass == 0)
        {
            inventoryNotifGO.SetActive(false);
        }
    }

    public void CouldBeInventory() => _couldBeInInventory = true;

}
