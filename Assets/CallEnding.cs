using UnityEngine;
using UnityEngine.Events;

public class CallEnding : MonoBehaviour
{
    public UnityEvent CallOutroEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("There");
        CallOutroEvent.Invoke();
    }
}
