using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField]
    private float movementTime = 0.2f;

    [SerializeField]
    private float speed;

    [SerializeField]
    private LayerMask groundLayer;

    private Rigidbody2D rb;

    private Vector3 startingPosition;
    private Vector3 destinationPosition;

    private Coroutine coroutine;

    public bool isMoving = false;
    private bool isOnSlope = false;

    public UnityEvent stopMoving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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
            rb.velocity = new Vector2(speed, rb.velocity.y);
            //coroutine = StartCoroutine(HandleMovement());
        }
    }

    public IEnumerator HandleMovement()
    {
        float elapsedTime = 0;

        startingPosition = transform.position;
        destinationPosition = startingPosition + GetMovementDirection();

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

    private Vector3 GetMovementDirection()
    {
        Vector3 direction = Vector3.right;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        if (hit.collider != null)
        {
            Vector3 slopeNormal = hit.normal;
            if (Mathf.Abs(slopeNormal.x) > 0.01f)
            {
                direction.y = Mathf.Abs(slopeNormal.x) * Mathf.Sign(slopeNormal.y);
            }
        }

        return direction;
    }
}
