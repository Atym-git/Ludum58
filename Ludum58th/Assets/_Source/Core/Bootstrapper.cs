using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private CoroutineRunner coroutineRunner;

    private void Awake()
    {
        PlayerMovement playerMovement = new();
        CursorTrack cursorTrack = new();

        InventoryVisualizer inventoryVisualizer = new InventoryVisualizer(playerData.InventoryIconsParent,
                                                                          coroutineRunner);

        Invoker invoker = new(playerMovement, playerData, cursorTrack, inventoryVisualizer);

        Inventory inventory = new Inventory(invoker);

        inputListener.Construct(invoker);

    }
}
