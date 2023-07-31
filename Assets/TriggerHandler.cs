using UnityEngine;
using UnityEngine.Events;

public class TriggerHandler : MonoBehaviour
{
    public Collider2D collided = null;

    public UnityEvent entryEvent;
    public UnityEvent exitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collided = collision;
        entryEvent.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collided = null;
        exitEvent.Invoke();
    }
}
