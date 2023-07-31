using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int sceneBuildIndex;

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    private float delayPress = .25f;
    private float passedTimeSincePress;
    private float TimeOnPress;
    private float slopeDownAngle;
    private float slopeUpAngle;
    private float lastSlopeAngle;

    private bool firstPress = false;
    private bool keyPressed = false;
    private bool isOnSlope;

    private Vector2 colliderSize;
    private Vector2 slopeNormalPerp;

    private Collider2D activeCollider;

    [SerializeField]
    private float slopeCheckDistance;

    [SerializeField]
    private LayerMask ground;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        colliderSize = bc.size;
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
            else if (Time.time - TimeOnPress >= delayPress)
            {
                if (isOnSlope)
                {
                    rb.velocity = new Vector2(speed * -slopeNormalPerp.x, rb.velocity.y * -slopeNormalPerp.y);
                }
                else
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
            }
        }

        if (Time.time - passedTimeSincePress > delayPress && firstPress)
        {
            if (!keyPressed)
            {
                Debug.Log(activeCollider.gameObject.name);
                if (activeCollider.gameObject.name == "Level")
                {
                    SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
                }
                else if (activeCollider.gameObject.name == "Ladder")
                {
                    Debug.Log("Ladder");
                    transform.position = new Vector3(transform.position.x, activeCollider.GetComponent<LadderData>().LedderCords.y, transform.position.z);
                }
                else if (activeCollider.gameObject.name.Contains("Tube"))
                {
                    //string tube_name = activeCollider.gameObject.name.Split('_');
                    //Debug.Log(tube_name);
                }
            }
            firstPress = false;
        }
    }

    private void FixedUpdate()
    {
        //SlopeCheck();
    }

    private void SlopeCheck()
    {
        Vector2 checkPos = transform.position - (Vector3)(new Vector2(0.0f, colliderSize.y / 2));

        //horizontalSlopeCheck(checkPos);
        verticalSlopeCheck(checkPos);
    }

    private void horizontalSlopeCheck(Vector2 checkPos)
    {
        RaycastHit2D slopeHitFront = Physics2D.Raycast(checkPos, transform.right, slopeCheckDistance, ground);
        RaycastHit2D slopeHitBack = Physics2D.Raycast(checkPos, -transform.right, slopeCheckDistance, ground);

        if (slopeHitFront)
        {
            isOnSlope = true;
        }
        else if (slopeHitBack)
        {
            isOnSlope = true;
        }
        else
        {
            isOnSlope = false;
        }
    }

    private void verticalSlopeCheck(Vector2 checkPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, slopeCheckDistance, ground);

        if (hit)
        {
            slopeNormalPerp = Vector2.Perpendicular(hit.normal).normalized;

            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

            if (slopeDownAngle != lastSlopeAngle)
            {
                isOnSlope = true;
            }

            lastSlopeAngle = slopeDownAngle;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        activeCollider = collider;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        activeCollider = null;
    }
}
