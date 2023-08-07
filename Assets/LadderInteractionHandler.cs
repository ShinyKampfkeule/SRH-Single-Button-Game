using UnityEngine;

public class LadderInteractionHandler : MonoBehaviour
{
    [SerializeField]
    public GameObject NewPlayerPosition = null;

    [SerializeField]
    private GameObject player;

    public void PlayerInteraction()
    {
        Collider2D collider = player.GetComponent<TriggerHandler>().collided;
        if (collider != null && collider.name == transform.name)
        {
            player.transform.position = NewPlayerPosition.transform.position;
        }
    }
}
