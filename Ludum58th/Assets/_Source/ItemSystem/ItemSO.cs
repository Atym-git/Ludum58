using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO",
 menuName = "SO/Item/New Item")]
public class ItemSO : ScriptableObject
{
    [field: SerializeField]
    public Sprite ItemSprite { get; private set; }
    
    [field: SerializeField]
    public GameObject ItemPrefab { get; private set; }

    [field: SerializeField]
    public string ItemNotificationText { get; private set; }
    
    [field: SerializeField]
    public float ItemNotificationDuration { get; private set; }
    
    [field: SerializeField]
    public float ItemIconDisplayDuration { get; private set; }
    
    [field: SerializeField]
    public bool CouldBeInInventory { get; private set; }
}
