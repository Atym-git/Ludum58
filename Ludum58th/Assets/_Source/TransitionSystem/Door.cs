using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int teleportToIndex = 100;

    private void OnMouseDown()
    {
        Invoker.InvokeTeleportTo(teleportToIndex);
    }

}
