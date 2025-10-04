using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private PlayerData playerData;

    [SerializeField] private Transform inventoryIconsParent;

    private void Awake()
    {
        PlayerMovement playerMovement = new();
        CursorTrack cursorTrack = new();

        Invoker invoker = new(playerMovement, playerData, cursorTrack);

        inputListener.Construct(invoker);

        InventoryVisualizer inventoryVisualizer = new InventoryVisualizer(inventoryIconsParent);
        Inventory inventory = new Inventory(inventoryVisualizer);
    }
}
