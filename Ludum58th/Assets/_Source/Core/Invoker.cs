using UnityEngine;

public class Invoker
{
    private PlayerMovement _playerMovement;
    private PlayerData _playerData;
    private CursorTrack _cursorTrack;
    private InventoryVisualizer _inventoryVisualizer;

    //private LayerMask _itemLayerMask;

    public Invoker(PlayerMovement playerMovement, PlayerData playerData, CursorTrack cursorTrack, InventoryVisualizer inventoryVisualizer)
    {
        _playerMovement = playerMovement;
        _playerData = playerData;
        _cursorTrack = cursorTrack;
        _inventoryVisualizer = inventoryVisualizer;
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

    public void InvokeShowInv(Item item, int itemIndex)
    {
        _inventoryVisualizer.ShowItems(item,
                                       itemIndex,
                                       _playerData.InventoryNotifTMP,
                                       _playerData.NotificationDuration);
    }
}
