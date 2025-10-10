using System.Collections.Generic;
using UnityEngine;

public class Invoker
{
    private PlayerMovement _playerMovement;
    private static PlayerData _playerData;
    private CursorTrack _cursorTrack;
    private InventoryVisualizer _inventoryVisualizer;
    private ItemFabric _itemFabric;
    private ResourceLoader _resourceLoader;
    private CoroutineRunner _coroutineRunner;
    private PhotoDisplay _photoDisplay;
    private SFXPlayer _sFXPlayer;

    private static Transition _transition;

    public Invoker(PlayerMovement playerMovement,
                   PlayerData playerData,
                   CursorTrack cursorTrack,
                   InventoryVisualizer inventoryVisualizer,
                   Transition transition,
                   ItemFabric itemFabric,
                   ResourceLoader resourceLoader,
                   CoroutineRunner coroutineRunner,
                   PhotoDisplay photoDisplay,
                   SFXPlayer sFXPlayer)
    {
        _playerMovement = playerMovement;
        _playerData = playerData;
        _cursorTrack = cursorTrack;
        _inventoryVisualizer = inventoryVisualizer;
        _itemFabric = itemFabric;
        _resourceLoader = resourceLoader;
        _coroutineRunner = coroutineRunner;
        _transition = transition;
        _photoDisplay = photoDisplay;
        _sFXPlayer = sFXPlayer;

        InvokeItemsSpawn();
    }

    public void InvokeMove(float vertMoveF)
    {
        _playerMovement.Move(vertMoveF,
                             _playerData.PlayerSpeed,
                             _playerData.PlayerRb, 
                             _playerData.CharacterTransform,
                             _playerData.PlayerAnimator,
                             _playerData.AnimatorBoolParameterName);
    }

    public void InvokeCursorTrack()
    {
        _cursorTrack.TrackOnClick(Camera.main);
    }

    public void InvokeItemsSpawn()
    {
        ItemSO[] itemSOs = _resourceLoader.LoadItemsSO();
        _itemFabric.InstantiateItems(itemSOs, _coroutineRunner);
    }

    public void InvokeShowInv(Item item, int itemIndex)
    {
        _inventoryVisualizer.ShowItems(item,
                                       itemIndex);
    }

    public void InvokeItemsRemap(List<Item> items)
    {
        _inventoryVisualizer.RemapItemsPlaces(items);
    }

    public static void InvokeTeleportTo(Transform teleportToTransform)
    {
        _transition.TeleportTo(_playerData.transform, teleportToTransform, _playerData.BlackScreen);
    }

    public void InvokePhotoDisplay()
    {
        _photoDisplay.ShowPhoto();
    }

    public void InvokePlaySFXClip(Transform spawnedGOTransform)
    {
        _sFXPlayer.PlaySoundFXClip(_playerData.clickAudioClip, spawnedGOTransform, 0.25f);
    }

}
