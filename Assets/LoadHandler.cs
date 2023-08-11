using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadHandler : MonoBehaviour
{
    public Animator animatorTop = null;
    public Image blackTop = null;
    public Animator animatorBottom = null;
    public AudioSource levelMusic = null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("loadLevel");
    }

    private IEnumerator loadLevel()
    {
        animatorBottom.SetBool("Fade", true);
        animatorTop.SetBool("Fade", true);
        yield return new WaitUntil(() => blackTop.color.a == 0);
        levelMusic.Play();
    }
}
