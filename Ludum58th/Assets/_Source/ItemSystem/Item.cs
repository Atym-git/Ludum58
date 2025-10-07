using TMPro;
using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    private const string INVENTORY_NOTIFICATION_TMP_TAG = "InventoryNotificationTMP";

    [field: SerializeField]
    public Sprite ItemSprite { get; private set; }

    private GameObject _itemPrefab;

    [SerializeField] private string _itemNotifText;

    [field: SerializeField]
    public float NotificationDuration { get; private set; }

    private float _itemIconDisplayDuration;

    private bool _couldBeInInventory;

    private GameObject _inventoryNotifPanel;

    private TextMeshProUGUI _inventoryNotifTMP;

    [SerializeField] private CoroutineRunner _coroutineRunner;

    public void Construct(Sprite itemSprite,
                          string itemNotifText,
                          float itemNotifDuration,
                          float itemIconDisplayDuration,
                          bool couldBeInInventory,
                          GameObject itemPrefab,
                          GameObject inventoryNotifPanel,
                          CoroutineRunner coroutineRunner)
    {
        ItemSprite = itemSprite;
        _itemNotifText = itemNotifText;
        NotificationDuration = itemNotifDuration;
        _couldBeInInventory = couldBeInInventory;
        _itemPrefab = itemPrefab;
        _inventoryNotifPanel = inventoryNotifPanel;
        _coroutineRunner = coroutineRunner;

        GetComponent<SpriteRenderer>().sprite = itemSprite;
    }

    //public void OnMouseDown()
    //{
    //    OnClick();
    //}

    private void Start()
    {
        //InventoryNotifTMP = GameObject.FindGameObjectWithTag(INVENTORY_NOTIFICATION_TMP_TAG)
        //    .GetComponent<TextMeshProUGUI>();

        if (_itemPrefab != null)
        {
            GameObject itemInstance3D = Instantiate(_itemPrefab, transform);
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

    public void OnClick()
    {
        Item item = gameObject.GetComponent<Item>();
        if (_couldBeInInventory)
        {
            //GameObject itemCloneGO = Instantiate(item.gameObject);
            //Item itemClone = itemCloneGO.GetComponent<Item>();
            Inventory.AddItem(item);
        }

        _inventoryNotifTMP.text = item._itemNotifText;

        _coroutineRunner.RunCoroutine(NotifyDuration(NotificationDuration, _inventoryNotifPanel));
    }

    public void SelfDestruct() => Destroy(gameObject);

    public void DisableItem() => gameObject.SetActive(false);

    private IEnumerator NotifyDuration(float seconds, GameObject inventoryNotifGO)
    {
        inventoryNotifGO.SetActive(true);
        yield return new WaitForSeconds(seconds);
        inventoryNotifGO.SetActive(false);
    }

}
