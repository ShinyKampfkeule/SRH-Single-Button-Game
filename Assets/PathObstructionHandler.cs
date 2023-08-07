using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathObstructionHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject connectedObstruction;

    [SerializeField]
    private GameObject obstructionCollider;

    [SerializeField]
    private AudioSource vanishingSound;

    private bool playerIsHere = false;

    public void PlayerEntered()
    {
        Collider2D collider = player.GetComponent<TriggerHandler>().collided;
        if (collider != null && collider.name == transform.name)
        {
            playerIsHere = true;
        }
    }

    public void PlayerLeft()
    {
        Collider2D collider = player.GetComponent<TriggerHandler>().collided;
        if (playerIsHere && collider != null && collider.name != transform.name)
        {
            playerIsHere = false;
        }
    }

    private void Update()
    {
        if (playerIsHere && connectedObstruction.GetComponent<PathObstructionHandler>().playerIsHere)
        {
            vanishingSound.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            obstructionCollider.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
