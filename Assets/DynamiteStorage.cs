using UnityEngine;

public class DynamiteStorage : MonoBehaviour
{
    public int TopDynamite = 0;
    public int BottomDynamite = 0;

    public void increaseTopDynamite()
    {
        TopDynamite++;
    }

    public void decreaseTopDynamite()
    {
        TopDynamite--;
    }
    public void increaseBottomDynamite()
    {
        BottomDynamite++;
    }

    public void decreaseBottomDynamite()
    {
        BottomDynamite--;
    }
}
