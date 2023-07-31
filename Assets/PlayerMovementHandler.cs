using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rb;
    private CapsuleCollider2D cc;

    private float passedTimeSincePress;
    private float delayPress = .25f;
    private float TimeOnPress;
    private float movementTime = 0.2f;

    private bool firstPress = false;
    private bool keyPressed = false;
    private bool moving = false;

    private Vector2 colliderSize;

    private Vector3 startingPosition;
    private Vector3 destinationPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();

        colliderSize = cc.size;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !keyPressed)
        {
            if (firstPress)
            {
                bool isDoublePressed = Time.time - passedTimeSincePress <= delayPress;
                Debug.Log(isDoublePressed);
                if (isDoublePressed)
                {
                    Debug.Log("Double Pressed");
                    firstPress = false;
                }
            }
            else
            {
                TimeOnPress = Time.time;
                keyPressed = true;
                firstPress = true;
            }
            passedTimeSincePress = Time.time;
        }

        else if (keyPressed)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                keyPressed = false;
            }
            else if (Time.time - TimeOnPress >= delayPress && !moving)
            {
                StartCoroutine(HandleMovement());
            }
        }

        if (Time.time - passedTimeSincePress > delayPress && firstPress)
        {
            if (!keyPressed)
            {
                
            }
            firstPress = false;
        }
    }

    private IEnumerator HandleMovement()
    {
        moving = true;

        float elapsedTime = 0;

        startingPosition = transform.position;
        destinationPosition = startingPosition + Vector3.right;

        while (elapsedTime < movementTime)
        {
            transform.position = Vector3.Lerp(startingPosition, destinationPosition, (elapsedTime / movementTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = destinationPosition;

        moving = false;
    }
}
