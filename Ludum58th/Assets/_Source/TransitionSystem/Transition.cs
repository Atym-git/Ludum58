using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Transition
{
    private List<Transform> _teleportRoots = new();

    private const int BLACK_SCREEN_DURATION = 1;

    private CoroutineRunner _runner;

    public Transition(Transform teleportRootsParent, CoroutineRunner coroutineRunner)
    {
        _runner = coroutineRunner;

        Debug.Log("CoroutineRunner: " + coroutineRunner);
        Debug.Log("Runner: " + _runner);

        GetTransformsFromParent(teleportRootsParent);
    }

    private void GetTransformsFromParent(Transform rootsParent)
    {
        for (int i = 0; i < rootsParent.childCount; i++)
        {
            _teleportRoots.Add(rootsParent.GetChild(i));
        }
    }

    public void TeleportTo(Transform playerTransform, int index, GameObject blackScreen)
    {
        if (index < _teleportRoots.Count)
        {
            _runner.RunCoroutine(Loading(blackScreen));
            playerTransform.position = _teleportRoots[index].position;
        }
    }

    private IEnumerator Loading(GameObject blackScreen)
    {
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(BLACK_SCREEN_DURATION);
        blackScreen.SetActive(false);
    }
}
