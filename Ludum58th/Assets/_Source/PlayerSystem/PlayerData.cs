using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Player Variables")]
    [field:SerializeField]
    public float PlayerSpeed { get; private set; }

    [Header("Player GameComponents (Don't touch)")]

    [field:SerializeField]
    public Rigidbody2D PlayerRb { get; private set; }

    [Header("Inventory Data")]

    [field:SerializeField]
    public float NotificationDuration { get; private set; }
    
    [field:SerializeField]
    public Transform InventoryIconsParent { get; private set; }
    
    [field:SerializeField]
    public TextMeshProUGUI InventoryNotifTMP { get; private set; }

}
