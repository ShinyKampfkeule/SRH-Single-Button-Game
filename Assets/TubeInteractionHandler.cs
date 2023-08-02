using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeInteractionHandler : MonoBehaviour
{
    [SerializeField]
    public int ExitCoordX = 0;

    [SerializeField]
    private GameObject player;

    private bool playerIsHere = false;

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
        if (playerIsHere && player.GetComponent<TriggerHandler>().collided.name == transform.name)
        {
            player.transform.localPosition = new Vector3(ExitCoordX, player.transform.localPosition.y, player.transform.localPosition.z);
        }
    }
}
