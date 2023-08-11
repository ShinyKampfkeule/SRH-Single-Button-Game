using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public void MoveImage()
    {
        //Collider2D collider = player.GetComponent<TriggerHandler>().collided;
        //if (collider != null && collider.name == transform.name)
        //{
        //    transform.position = new Vector3(transform.position.x * 3, transform.position.y, transform.position.z);
        //}
    }
}
