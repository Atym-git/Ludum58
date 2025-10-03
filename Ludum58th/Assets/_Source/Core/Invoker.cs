using UnityEngine;

public class Invoker
{
    private PlayerMovement _playerMovement;
    private PlayerData _playerData;
    private CursorTrack _cursorTrack;

    private LayerMask _itemLayerMask;

    public Invoker(PlayerMovement playerMovement, PlayerData playerData, CursorTrack cursorTrack)
    {
        _playerMovement = playerMovement;
        _playerData = playerData;
        _cursorTrack = cursorTrack;
    }

    public void InvokeMove(float vertMoveF)
    {
        _playerMovement.Move(vertMoveF, _playerData.PlayerSpeed, _playerData.PlayerRb);
    }

    public void InvokeCursorTrack()
    {
        _cursorTrack.TrackOnClick(Camera.main, _itemLayerMask);
    }
}
