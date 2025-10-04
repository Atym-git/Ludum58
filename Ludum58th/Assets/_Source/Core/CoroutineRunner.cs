using System.Collections;
using UnityEngine;

public class CoroutineRunner : MonoBehaviour
{
    public void RunCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
    
    public void StopRunningCoroutine(IEnumerator coroutine)
    {
        StopCoroutine(coroutine);
    }
}
