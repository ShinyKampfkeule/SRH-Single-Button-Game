using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderInteractionHandler : MonoBehaviour
{

    [SerializeField]
    public Vector3 LedderCords = Vector3.zero;

    [SerializeField]
    public Vector3 PlayerClimbFinalPosition = Vector3.zero;

    [SerializeField]
    private GameObject player;

    private bool playerIsHere = false;
    private bool isOnCorrectPosition = false;

    public void PlayerEntered()
    {
        playerIsHere = true;
    }

    public void PlayerLeft()
    {
        playerIsHere = false;
    }

    public void PlayerInteraction()
    {
        if (playerIsHere && player.GetComponent<TriggerHandler>().collided.name == transform.name && !transform.name.Contains("WorldBoundary"))
        {
            if (!isOnCorrectPosition)
            {
                transform.localPosition = LedderCords;
                isOnCorrectPosition = true;
            }
            else
            {
                player.transform.localPosition = PlayerClimbFinalPosition;
            }
        }
    }
}
