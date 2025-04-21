using System.Collections;
using UnityEngine;
using UnityScreenLogger;
using UnityScreenLogger.Core;

public class LoggerTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TestSequence());
    }

    private IEnumerator TestSequence(){
        USLDebug.Log("This is a test log");
        yield return new WaitForSeconds(2);
        USLDebug.Warning("This is a warning");
        yield return new WaitForSeconds(2);
        USLDebug.Error("This is an Error");
    }
}
