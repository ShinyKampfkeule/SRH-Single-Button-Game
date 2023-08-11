using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PathObstructionHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject connectedObstruction;

    [SerializeField] 
    private GameObject connectedCollider;

    [SerializeField]
    private GameObject obstructionCollider;

    [SerializeField]
    private AudioSource vanishingSound;

    public bool playerIsHere = false;

    public UnityEvent Ending;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        playerIsHere = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        playerIsHere = false;
    }

    private void FixedUpdate()
    {
        if (playerIsHere && connectedObstruction.GetComponent<PathObstructionHandler>().playerIsHere)
        {
            vanishingSound.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            connectedObstruction.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            connectedObstruction.GetComponent<BoxCollider2D>().enabled = false;
            obstructionCollider.GetComponent<BoxCollider2D>().enabled = false;
            connectedCollider.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
