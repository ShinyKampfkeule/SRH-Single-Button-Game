using UnityEngine;

public class SpacebarAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator spacebarAnimator = null;

    [SerializeField]
    private int animationType = 0; //0 = tap, 1 = double tap, 2 = hold

    // Start is called before the first frame update
    void Awake()
    {
        if (animationType == 0)
        {
            spacebarAnimator.SetBool("DoubleTap", false);
            spacebarAnimator.SetBool("Hold", false);
        }
        else if (animationType == 1)
        {
            spacebarAnimator.SetBool("DoubleTap", true);
        }
        else if (animationType == 2)
        {
            spacebarAnimator.SetBool("Hold", true);
        }
    }
}
