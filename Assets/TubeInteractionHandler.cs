using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeInteractionHandler : MonoBehaviour
{
    [SerializeField]
    public GameObject ExitTube = null;

    [SerializeField]
    private GameObject player;

    public void PlayerInteraction()
    {
        Collider2D collider = player.GetComponent<TriggerHandler>().collided;
        if (collider != null && collider.name == transform.name)
        {
            player.transform.position = ExitTube.transform.position;
        }
    }
}
