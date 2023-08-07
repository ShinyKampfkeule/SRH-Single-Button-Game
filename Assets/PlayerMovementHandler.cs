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

    [SerializeField]
    private Animator animator;

    public AudioSource runningSounds;

    private Rigidbody2D rb;

    public bool isMoving = false;

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
        if (isMoving)
        {
            if (!runningSounds.isPlaying)
            {
                runningSounds.Play();
            }
            if (animator.GetFloat("Speed") == 0)
            {
                animator.SetFloat("Speed", speed);
            }
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            if (animator.GetFloat("Speed") != 0)
            {
                animator.SetFloat("Speed", 0);
                runningSounds.Stop();
            }
        }
    }
}
