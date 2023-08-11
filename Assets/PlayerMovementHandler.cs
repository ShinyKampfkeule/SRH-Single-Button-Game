using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioSource runningSounds;

    private Rigidbody2D rb;

    private bool isMoving = false;
    public bool inCutscene = false;

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
        if (isMoving && !inCutscene)
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
        else if (!inCutscene)
        {
            if (animator.GetFloat("Speed") != 0)
            {
                animator.SetFloat("Speed", 0);
                runningSounds.Stop();
            }
        }
    }
}
