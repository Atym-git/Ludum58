using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private CoroutineRunner runner;
    [SerializeField] private GameEnder gameEnder;

    [SerializeField] private List<Slot> slots = new();

    [SerializeField] private GameObject photo;

    [SerializeField] private AudioSource sFXPlayerPrefab;

    [field:Header("Item Data")]
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private List<Transform> itemRoots = new();
    [SerializeField] private GameObject inventoryNotifPanel;

    private void Awake()
    {
        PlayerMovement playerMovement = new();
        CursorTrack cursorTrack = new();
        ResourceLoader loader = new();

        PhotoDisplay photoDisplay = new PhotoDisplay(photo);

        SFXPlayer sFXPlayer = new SFXPlayer(sFXPlayerPrefab);

        ItemFabric itemFabric = new ItemFabric(itemPrefab,
                                               itemRoots,
                                               inventoryNotifPanel);

        Transition transition = new Transition(runner);

        InventoryVisualizer inventoryVisualizer = new InventoryVisualizer(playerData.InventoryIconsParent,
                                                                          runner);

        Invoker invoker = new Invoker(playerMovement,
                                      playerData,
                                      cursorTrack,
                                      inventoryVisualizer,
                                      transition,
                                      itemFabric,
                                      loader,
                                      runner,
                                      photoDisplay,
                                      sFXPlayer);

        IsPhotoDone isPhotoDone = new IsPhotoDone(gameEnder.photoSlots, gameEnder);

        Inventory inventory = new Inventory(invoker);

        inputListener.Construct(invoker);

        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].Construct(inventory, isPhotoDone);
        }
    }
}
