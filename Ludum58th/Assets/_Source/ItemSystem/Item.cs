using TMPro;
using UnityEngine;
using System.Collections;
using static UnityEditor.Progress;
using Unity.VisualScripting;

public class Item : MonoBehaviour
{
    [field:SerializeField]
    public Sprite ItemSprite {  get; private set; }

    private string _itemNotifText;

    private float _itemNotifDuration;
    private float _itemIconDisplayDuration;

    private bool _couldBeInInventory;
    
    private TextMeshProUGUI _inventoryNotifTMP;

    private const string INVENTORY_NOTIFICATION_TMP_TAG = "InventoryNotificationTMP";

    private CoroutineRunner _coroutineRunner;

    public void Construct(Sprite itemSprite,
                          string itemNotifText,
                          float itemNotifDuration,
                          float itemIconDisplayDuration,
                          bool couldBePickedUp, 
                          CoroutineRunner coroutineRunner)
    {
        ItemSprite = itemSprite;
        _itemNotifText = itemNotifText;
        _itemNotifDuration = itemNotifDuration;
        _couldBeInInventory = couldBePickedUp;
        _coroutineRunner = coroutineRunner;

        GetComponent<SpriteRenderer>().sprite = itemSprite;
    }

    public void OnMouseDown()
    {
        OnClick();
    }

    private void Start()
    {
        _inventoryNotifTMP = GameObject.FindGameObjectWithTag(INVENTORY_NOTIFICATION_TMP_TAG)
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

        _inventoryNotifTMP.text = item._itemNotifText;

        _coroutineRunner.RunCoroutine(NotifyDuration(_itemNotifDuration, _inventoryNotifTMP.gameObject));
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
