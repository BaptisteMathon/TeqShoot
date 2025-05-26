using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public bool isJumping = false;
    public bool isGrounded;
    public bool isDashing = false;

    public int Dash;
    private int jumpCount = 0;


// -----------------------------

    public Rigidbody2D rb;
    public Animator animator;
    public Transform GroundCheckLeft;
    public Transform GroundCheckRight;
    private Vector3 velocity = Vector3.zero;
    public SpriteRenderer spriteRenderer;
    public ProjectileBehavior ProjectilePrefab;
    public Transform LaunchOffSetRight;
    public Transform LaunchOffSetLeft;

    void Start()
    {

    }

    void Update()
    {

        if (isGrounded)
        {
            jumpCount = 0;
        }
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < 1))
        {
            jumpCount++;
            isJumping = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Shooting");

            if (spriteRenderer.flipX)
            {
                //     Instantiate(ProjectilePrefab, LaunchOffSetLeft.position, transform.rotation);
                GameObject proj = Instantiate(ProjectilePrefab.gameObject, LaunchOffSetLeft.position, Quaternion.identity);
                proj.GetComponent<ProjectileBehavior>().direction = Vector2.left;
            }
            else
            {
                //     Instantiate(ProjectilePrefab, LaunchOffSetRight.position, transform.rotation);
                GameObject proj = Instantiate(ProjectilePrefab.gameObject, LaunchOffSetRight.position, Quaternion.identity);
                proj.GetComponent<ProjectileBehavior>().direction = Vector2.right;
            }
        }

        if ((Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.LeftShift)) && !isDashing)
        {
            rb.velocity = new Vector2(Dash, rb.velocity.y);
            isDashing = true;
        }
        if ((Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.LeftShift)) && !isDashing)
        {
            rb.velocity = new Vector2(-Dash, rb.velocity.y);
            isDashing = true;
        }

        if (isGrounded)
        {
            isDashing = false;
        }
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapArea(GroundCheckLeft.position, GroundCheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        if (isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }        
    }
}
