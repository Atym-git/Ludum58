using TMPro;
using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    [field: SerializeField]
    public Sprite ItemSprite { get; private set; }

    public GameObject ItemPrefab {  get; private set; }

    [field: SerializeField]
    public float NotificationDuration { get; private set; }

    [SerializeField] private string _itemNotifText;

    private float _itemIconDisplayDuration;

    private bool _couldBeInInventory;
    private bool _readyToMove;

    [SerializeField] private float _moveTowardsXAfterPress;

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
            transform.position = Vector3.MoveTowards(transform.position, moveTo, 0.03f);
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

    public void CouldBeInventory() => _couldBeInInventory = true;

}
