using UnityEngine;
using UnityEngine.UI;

public class DynamiteHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private bool isTopDynamite = false;

    [SerializeField]
    private DynamiteStorage dynamiteStorage = null;

    [SerializeField]
    private Text dynamiteText = null;

    public bool isCollected = false;

    public void CollectDynamite()
    {
        Collider2D collider = player.GetComponent<TriggerHandler>().collidedDynamite;
        if (!isCollected && collider != null && collider.name == transform.name)
        {
            GetComponent<SpriteRenderer>().sprite = null;
            if (isTopDynamite)
            {
                dynamiteStorage.increaseTopDynamite();
                dynamiteText.text = dynamiteStorage.TopDynamite.ToString();
            }
            else
            {
                dynamiteStorage.increaseBottomDynamite();
                dynamiteText.text = dynamiteStorage.BottomDynamite.ToString();
            }
            isCollected = true;
        }
    }
}
