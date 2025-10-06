using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private CoroutineRunner runner;
    [SerializeField] private List<Slot> slots = new();

    [SerializeField] private Transform teleportRootsParent;

    [field:Header("Item Data")]
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private List<Transform> itemRoots = new();

    private void Awake()
    {
        PlayerMovement playerMovement = new();
        CursorTrack cursorTrack = new();
        ResourceLoader loader = new();

        //fddd

        ItemFabric itemFabric = new(itemPrefab,
                                    itemRoots);

        Transition transition = new Transition(teleportRootsParent, runner);

        InventoryVisualizer inventoryVisualizer = new InventoryVisualizer(playerData.InventoryIconsParent,
                                                                          runner);

        Invoker invoker = new(playerMovement,
                              playerData,
                              cursorTrack,
                              inventoryVisualizer,
                              transition,
                              itemFabric,
                              loader,
                              runner);

        Inventory inventory = new Inventory(invoker);

        inputListener.Construct(invoker);

        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].Construct(inventory);
        }
    }
}
