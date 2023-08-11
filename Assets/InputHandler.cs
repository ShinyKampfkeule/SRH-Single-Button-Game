using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public UnityEvent buttonHold;
    public UnityEvent buttonHoldReleased;
    public UnityEvent buttonPress;
    public UnityEvent buttonDoublePress;

    public Inputs inputs;

    public bool timerStart = false;

    private void Awake()
    {
        inputs = new Inputs();
        inputs.Enable();
    }

    private void OnEnable()
    {
        inputs.Main.Hold.performed += OnHold;
        inputs.Main.Hold.canceled += OnHoldRelease;
        inputs.Main.DoubleTap.performed += OnDoubleTap;
        inputs.Main.Tap.performed += OnTap;
        inputs.Main.Exit.performed += OnExit;
    }

    private void OnHold(InputAction.CallbackContext context)
    {
        if (!timerStart)
        {
            timerStart = true;
        }
        buttonHold.Invoke();
    }

    private void OnHoldRelease(InputAction.CallbackContext context)
    {
        buttonHoldReleased.Invoke();
    }

    private void OnDoubleTap(InputAction.CallbackContext context)
    {
        buttonDoublePress.Invoke();
    }

    private void OnTap(InputAction.CallbackContext context)
    {
        buttonPress.Invoke();
    }

    private void OnExit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }

    public void disableInputs()
    {
        inputs.Disable();
    }

    public void enableInputs()
    {
        inputs.Enable();
    }
}
