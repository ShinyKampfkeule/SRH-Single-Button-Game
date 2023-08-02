using UnityEngine;
using UnityEngine.Events;

public class TriggerHandler : MonoBehaviour
{
    [SerializeField]
    public Collider2D collidedBackground = null;

    public Collider2D collided = null;

    public UnityEvent entryEvent;
    public UnityEvent exitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("Background"))
        {
            collidedBackground = collision;
        }
        else
        {
            collided = collision;
        }
        entryEvent.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.transform.name.Contains("Background"))
        {
            collided = null;
        }
        exitEvent.Invoke();
    }
}
