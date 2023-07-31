using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerHandler : MonoBehaviour
{

    public UnityEvent entryEvent;
    public UnityEvent exitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        entryEvent.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exitEvent.Invoke();
    }
}
