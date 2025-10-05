using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CoroutineRunner : MonoBehaviour
{
    public void RunCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
