using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private PlayerData playerData;

    private void Awake()
    {
        PlayerMovement playerMovement = new();
        CursorTrack cursorTrack = new();

        Invoker invoker = new(playerMovement, playerData, cursorTrack);

        inputListener.Construct(invoker);
    }
}
