using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class IntroHandler : MonoBehaviour
{
    [SerializeField]
    private Canvas page1 = null;

    [SerializeField]
    private Canvas page2 = null;

    [SerializeField]
    private Canvas page3 = null;

    private int page = 1;

    public Inputs inputs;

    private void Awake()
    {
        inputs = new Inputs();
        inputs.Enable();
        page2.enabled = false;
        page3.enabled = false;
    }

    private void OnEnable()
    {
        inputs.Main.Hold.performed += OnHold;
        inputs.Main.Tap.performed += OnTap;
    }

    private void OnHold(InputAction.CallbackContext context)
    {
        //SceneManager.LoadScene(1);
    }

    private void OnTap(InputAction.CallbackContext context)
    {
        if (page == 1)
        {
            page++;
            page1.enabled = false;
            page2.enabled = true;
        }
        else if (page == 2)
        {
            page++;
            page2.enabled = false;
            page3.enabled = true;
        }
        else if (page == 3)
        {
            page = 1;
            page3.enabled = false;
            SceneManager.LoadScene(1);
        }
    }
}
