using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderCollectionHandler : MonoBehaviour
{
    [SerializeField]
    public GameObject OriginalLadder = null;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private AudioSource collectionSound;

    public void CollectLadder()
    {
        Collider2D collider = player.GetComponent<TriggerHandler>().collidedCollectibleLadder;
        if (collider != null && collider.name == transform.name)
        {
            collectionSound.Play();
            OriginalLadder.GetComponent<SpriteRenderer>().enabled = true;
            OriginalLadder.GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
