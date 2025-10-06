using TMPro;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Item : MonoBehaviour
{
    private const string INVENTORY_NOTIFICATION_TMP_TAG = "InventoryNotificationTMP";

    [field:SerializeField]
    public Sprite ItemSprite {  get; private set; }

    [SerializeField] private string _itemNotifText;

    [field:SerializeField]
    public float NotificationDuration { get; private set; }

    private float _itemIconDisplayDuration;

    private bool _couldBeInInventory;
    
    public TextMeshProUGUI InventoryNotifTMP;

    [SerializeField] private CoroutineRunner _coroutineRunner;

    public void Construct(Sprite itemSprite,
                          string itemNotifText,
                          float itemNotifDuration,
                          float itemIconDisplayDuration,
                          bool couldBeInInventory,
                          CoroutineRunner coroutineRunner)
    {
        ItemSprite = itemSprite;
        _itemNotifText = itemNotifText;
        NotificationDuration = itemNotifDuration;
        _couldBeInInventory = couldBeInInventory;
        _coroutineRunner = coroutineRunner;

        GetComponent<SpriteRenderer>().sprite = itemSprite;
    }

    public void OnMouseDown()
    {
        OnClick();
    }

    private void Start()
    {
        InventoryNotifTMP = GameObject.FindGameObjectWithTag(INVENTORY_NOTIFICATION_TMP_TAG)
            .GetComponent<TextMeshProUGUI>();
    }

    private void OnClick()
    {
        Item item = gameObject.GetComponent<Item>();
        if (_couldBeInInventory)
        {
            //GameObject itemCloneGO = Instantiate(item.gameObject);
            //Item itemClone = itemCloneGO.GetComponent<Item>();
            Inventory.AddItem(item);
        }
        else
        {
            SelfDestruct();
        }

        InventoryNotifTMP.text = item._itemNotifText;

        _coroutineRunner.RunCoroutine(NotifyDuration(NotificationDuration, InventoryNotifTMP.gameObject));
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
