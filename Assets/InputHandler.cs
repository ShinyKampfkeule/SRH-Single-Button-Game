using System;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;

    private bool keyPressed = false;
    private bool firstPress = false;
    private bool playerIsMoving = false;
    private bool enemyIsInFront = false;

    private float delayPress = .25f;
    private float passedTimeSincePress = 0;
    private float timeOnPress = 0;

    public UnityEvent buttonHold;
    public UnityEvent buttonHoldReleased;
    public UnityEvent buttonPress;
    public UnityEvent buttonDoublePress;

    public Inputs inputs = null;

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
        inputs.Main.DoubleTap.canceled += OnDoubleTapCanceled;
    }

    private void OnHold(InputAction.CallbackContext context)
    {
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

    private void OnDoubleTapCanceled(InputAction.CallbackContext context)
    {
        buttonPress.Invoke();
    }

    public void changeMovement()
    {
        playerIsMoving = false;
    }

    public void encounterEnemy()
    {
        enemyIsInFront = true;
    }
}
