using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private CoroutineRunner runner;

    [SerializeField] private Transform teleportRootsParent;

    private void Awake()
    {
        PlayerMovement playerMovement = new();
        CursorTrack cursorTrack = new();

        Transition transition = new Transition(teleportRootsParent, runner);

        InventoryVisualizer inventoryVisualizer = new InventoryVisualizer(playerData.InventoryIconsParent,
                                                                          runner);

        Invoker invoker = new(playerMovement,
                              playerData,
                              cursorTrack,
                              inventoryVisualizer,
                              transition);

        Inventory inventory = new Inventory(invoker);

        inputListener.Construct(invoker);

    }
}
