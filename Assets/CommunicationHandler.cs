using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommunicationHandler : MonoBehaviour
{
    private bool communicating = false;

    private float delayPress = .25f;
    private float passedTimeSincePress;

    public UnityEvent communicationEvent;
    public UnityEvent exitCommunicationEvent;

    [SerializeField]
    public int communicationIndex = -1;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (communicating && Input.GetKeyDown(KeyCode.Space) && Time.time - passedTimeSincePress < delayPress)
        {
            communicationEvent.Invoke();
            communicationIndex++;
        }
    }

    public void SaySomething()
    {
        communicationIndex++;
        communicating = true;
        communicationEvent.Invoke();
    }

    public void LeaveCommunication()
    {
        communicating = false;
        exitCommunicationEvent.Invoke();
        communicationIndex = -1;
    }
}
