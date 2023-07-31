using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField]
    private float movementTime = 0.2f;

    private Vector3 startingPosition;
    private Vector3 destinationPosition;

    private Coroutine coroutine;

    public bool isMoving = false;

    public UnityEvent stopMoving;

    public void StartMovement ()
    {
        isMoving = true;
    }

    public void StoppMovement()
    {
        isMoving = false;
    }

    public void Update()
    {
        if (isMoving && coroutine == null)
        {
            coroutine = StartCoroutine(HandleMovement());
        }
    }

    public IEnumerator HandleMovement()
    {
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

        stopMoving.Invoke();
        coroutine = null;
    }
}
