using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    private List<Transform> teleportRoots = new();

    public void Teleport(Transform playerTransform, int index)
    {
        playerTransform.position = teleportRoots[index].position;
    }
}
