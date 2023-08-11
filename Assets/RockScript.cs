using UnityEngine;
using UnityEngine.UI;

public class RockScript : MonoBehaviour
{
    [SerializeField]
    private bool isTopRock = false;

    [SerializeField]
    private DynamiteStorage dynamiteStorage = null;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject stoneParent;

    [SerializeField]
    private Text dynamiteText = null;

    public void PlayerInteraction()
    {
        Collider2D collider = player.GetComponent<TriggerHandler>().collidedStone;
        if (collider != null && collider.name == transform.name)
        {
            if (isTopRock)
            {
                if (dynamiteStorage.TopDynamite > 0)
                {
                    dynamiteStorage.decreaseTopDynamite();
                    dynamiteText.text = dynamiteStorage.TopDynamite.ToString();
                    stoneParent.GetComponent<SpriteRenderer>().enabled = false;
                    stoneParent.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
            else
            {
                if (dynamiteStorage.BottomDynamite > 0)
                {
                    dynamiteStorage.decreaseBottomDynamite();
                    dynamiteText.text = dynamiteStorage.BottomDynamite.ToString();
                    stoneParent.GetComponent<SpriteRenderer>().enabled = false;
                    stoneParent.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }
}
