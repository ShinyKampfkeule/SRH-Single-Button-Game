using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommunicationHandler : MonoBehaviour
{
    private bool isCommunicating = false;

    public UnityEvent communicationEvent;
    public UnityEvent exitCommunicationEvent;

    [SerializeField]
    public int communicationIndex = -1;

    [SerializeField]
    private GameObject player;

    public void StartCommunication()
    {
        if (player.GetComponent<TriggerHandler>().collided.name == transform.name)
        {
            isCommunicating = true;
            SaySomething();
        }
    }

    public void SaySomething()
    {
        if (isCommunicating)
        {
            communicationIndex++;
            communicationEvent.Invoke();
        }
    }

    public void LeaveCommunication()
    {
        exitCommunicationEvent.Invoke();
        communicationIndex = -1;
        isCommunicating = false;
    }

    public void DoubleTapped()
    {
        Debug.Log("Double Tapped");
    }
}
