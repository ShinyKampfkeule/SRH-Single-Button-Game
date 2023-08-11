using UnityEngine;
using UnityEngine.Events;

public class TriggerHandler : MonoBehaviour
{
    [SerializeField]
    public Collider2D collidedBackground = null;
    public Collider2D collidedLadder = null;
    public Collider2D collidedCollectibleLadder = null;
    public Collider2D collidedStone = null;
    public Collider2D collidedDynamite = null;
    public Collider2D collidedTube = null;
    public Collider2D collidedPathObstruction = null;
    public Collider2D collidedNPC = null;

    public UnityEvent entryEvent;
    public UnityEvent exitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Background"))
        {
            collidedBackground = collision;
        }
        else if (collision.name.Contains("Entry"))
        {
            collidedTube = collision;
        }
        else if (collision.name.Contains("Collectible"))
        {
            collidedCollectibleLadder = collision;
        }
        else if (collision.name.Contains("Stone"))
        {
            collidedStone = collision;
        }
        else if (collision.name.Contains("Dynamite"))
        {
            collidedDynamite = collision;
        }
        else if (collision.name.Contains("Ladder"))
        {
            collidedLadder = collision;
        }
        else if (collision.name.Contains("Path"))
        {
            collidedPathObstruction = collision;
        }
        else if (collision.name.Contains("NPC"))
        {
            collidedNPC = collision;
        }
        entryEvent.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Contains("Background"))
        {
            collidedBackground = null;
        }
        else if (collision.name.Contains("Entry"))
        {
            collidedTube = null;
        }
        else if (collision.name.Contains("Collectible"))
        {
            collidedCollectibleLadder = null;
        }
        else if (collision.name.Contains("Stone"))
        {
            collidedStone = null;
        }
        else if (collision.name.Contains("Dynamite"))
        {
            collidedDynamite = null;
        }
        else if (collision.name.Contains("Ladder"))
        {
            collidedLadder = null;
        }
        else if (collision.name.Contains("Path"))
        {
            collidedPathObstruction = null;
        }
        exitEvent.Invoke();
    }
}
