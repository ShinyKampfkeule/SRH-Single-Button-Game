using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HideElement : MonoBehaviour
{
    [SerializeField]
    public Vector3 position;

    [SerializeField]
    public int iconIndex;

    public void ShowIcon()
    {
        CommunicationHandler communicationHandler = GetComponentInParent<CommunicationHandler>();
        if (communicationHandler.communicationIndex == iconIndex)
        {
            transform.localPosition = position;
        }
        else
        {
            transform.localPosition = new Vector3(5000, 5000, 5000);
        }
    }

    public void HideIcon()
    {
        CommunicationHandler communicationHandler = GetComponentInParent<CommunicationHandler>();
        if (communicationHandler.communicationIndex == iconIndex)
        {
            transform.localPosition = new Vector3(5000, 5000, 5000);
        }
    }
}
