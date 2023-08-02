using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public void MoveImage()
    {
        Debug.Log(player.GetComponent<TriggerHandler>().collided);
        if (player.GetComponent<TriggerHandler>().collided.name == transform.name)
        {
            transform.localPosition = new Vector3(transform.localPosition.x * 3, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
