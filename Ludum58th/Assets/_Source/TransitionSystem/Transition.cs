using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Transition
{
    private List<Transform> _teleportRoots = new();

    private const float BLACK_SCREEN_DURATION = 0.5f;

    private CoroutineRunner _runner;

    public Transition(CoroutineRunner coroutineRunner)
    {
        _runner = coroutineRunner;
    }

    private void GetTransformsFromParent(Transform rootsParent)
    {
        for (int i = 0; i < rootsParent.childCount; i++)
        {
            _teleportRoots.Add(rootsParent.GetChild(i));
        }
    }

    public void TeleportTo(Transform playerTransform, Transform teleportToTransform, GameObject blackScreen)
    {
        if (teleportToTransform != null)
        {
            _runner.RunCoroutine(Loading(blackScreen));
            playerTransform.position = teleportToTransform.position;
        }
    }

    private IEnumerator Loading(GameObject blackScreen)
    {
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(BLACK_SCREEN_DURATION);
        blackScreen.SetActive(false);
    }
}
