using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlopeHandler : MonoBehaviour
{

    public UnityEvent EnteredSlope;
    public UnityEvent ExitSlope;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.name.Contains("Start"))
        {
            EnteredSlope.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (transform.name.Contains("Goal"))
        {
            ExitSlope.Invoke();
        }
    }
}
