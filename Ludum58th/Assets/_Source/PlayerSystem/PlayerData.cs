using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Player Variables")]
    [field:SerializeField]
    public float PlayerSpeed { get; private set; }

    [Header("Player GameComponents (Don't touch)")]
    [field:SerializeField]
    public Rigidbody2D PlayerRb { get; private set; }
}
