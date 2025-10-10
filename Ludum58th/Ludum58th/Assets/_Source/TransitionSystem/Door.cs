using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform teleportToTransform;

    public void OnClick()
    {
        Invoker.InvokeTeleportTo(teleportToTransform);
    }

}
