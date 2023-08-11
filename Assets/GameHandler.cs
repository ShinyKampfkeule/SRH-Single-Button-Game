using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public AudioSource backgroundMusic = null;
    public AudioSource startSound = null;
    public float fadeoutTime = 2f;
    public Animator animator = null;
    public Image black = null;

    public Inputs inputs = null;

    private void Awake()
    {
        inputs = new Inputs();
        inputs.Enable();
    }

    private void OnEnable()
    {
        inputs.Main.Tap.performed += OnTap;
        inputs.Main.Exit.performed += OnExit;
    }

    private void OnExit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }

    private void OnTap(InputAction.CallbackContext context)
    {
        StartCoroutine("startGame");
    }

    private IEnumerator startGame()
    {
        animator.SetBool("Fade", true);
        startSound.Play();
        StartCoroutine(AudioFadeOut.FadeOut(backgroundMusic, fadeoutTime));
        yield return new WaitWhile(() => startSound.isPlaying);
        SceneManager.LoadScene(2);
    }
}