using UnityEngine;

public class Invoker
{
    private PlayerMovement _playerMovement;
    private static PlayerData _playerData;
    private CursorTrack _cursorTrack;
    private InventoryVisualizer _inventoryVisualizer;
    private ItemFabric _itemFabric;
    private ResourceLoader _resourceLoader;

    private static Transition _transition;

    //private LayerMask _itemLayerMask;

    public Invoker(PlayerMovement playerMovement,
                   PlayerData playerData,
                   CursorTrack cursorTrack,
                   InventoryVisualizer inventoryVisualizer,
                   Transition transition,
                   ItemFabric itemFabric,
                   ResourceLoader resourceLoader)
    {
        _playerMovement = playerMovement;
        _playerData = playerData;
        _cursorTrack = cursorTrack;
        _inventoryVisualizer = inventoryVisualizer;
        _itemFabric = itemFabric;
        _resourceLoader = resourceLoader;

        _transition = transition;
    }

    public void InvokeMove(float vertMoveF)
    {
        _playerMovement.Move(vertMoveF,
                             _playerData.PlayerSpeed,
                             _playerData.PlayerRb);
    }

    public void InvokeCursorTrack()
    {
        _cursorTrack.TrackOnClick(Camera.main/*, _itemLayerMask*/);
    }

    public void InvokeItemsSpawn()
    {
        ItemSO[] itemSOs = _resourceLoader.LoadItemsSO();
        _itemFabric.InstantiateItems( itemSOs);
    }

    public void InvokeShowInv(Item item, int itemIndex)
    {
        _inventoryVisualizer.ShowItems(item,
                                       itemIndex,
                                       _playerData.InventoryNotifTMP,
                                       _playerData.NotificationDuration);
    }

    public static void InvokeTeleportTo(Transform teleportToTransform)
    {
        _transition.TeleportTo(_playerData.transform, teleportToTransform, _playerData.BlackScreen);
    }
}
