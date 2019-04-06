using UnityEngine;

public class Hero : MonoBehaviour
{
    private IHeroMover land;
    private IHeroMover ladder;
    private IHeroMover heroMover;

    public Rigidbody2D rb2d;

    [SerializeField]
    private Transform[] RayPositions;

    public bool canJump;
    public bool isGrounded = true;

    public int vertical_input;
    public int horizontal_input;
    public bool jump_input;
    public bool action_input;
    public float holdingJumpSpeed;
    public bool isHoldingJump;

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        land = GetComponent<RunAround>();
        ladder = GetComponent<ClimbLadder>();
        land.Init(this);
        ladder.Init(this);

        heroMover = land;
    }

    public void Update()
    {
        DetectGround();
        GetInput();
        heroMover.Move();
        heroMover.Gravity();
        FlipSprite();
    }

    private void DetectGround()
    {
        LayerMask layermask = 1 << LayerMask.NameToLayer("Ground");

        RaycastHit2D[] rays = new RaycastHit2D[3];
        rays[0] = Physics2D.Raycast(RayPositions[0].position, Vector2.down, 0.1f, layermask);
        rays[1] = Physics2D.Raycast(RayPositions[1].position, Vector2.down, 0.1f, layermask);
        rays[2] = Physics2D.Raycast(RayPositions[2].position, Vector2.down, 0.1f, layermask);

        Debug.DrawRay(RayPositions[0].position, Vector2.down * 0.1f, Color.white);
        Debug.DrawRay(RayPositions[1].position, Vector2.down * 0.1f, Color.white);
        Debug.DrawRay(RayPositions[2].position, Vector2.down * 0.1f, Color.white);


        for (int i = 0; i < rays.Length; i++)
        {
            if (rays[i].collider)
            {
                isGrounded = true;

                if (!jump_input)
                    canJump = true;

                return;
            }
        }
        isGrounded = false;
    }

    private void GetInput()
    {
        if (Input.GetAxis("Horizontal") > 0)
            horizontal_input = 1;
        else if (Input.GetAxis("Horizontal") < 0)
            horizontal_input = -1;
        else
            horizontal_input = 0;

        if (Input.GetAxis("Vertical") > 0)
            vertical_input = 1;
        else if (Input.GetAxis("Vertical") < 0)
            vertical_input = -1;
        else
            vertical_input = 0;

        jump_input = Input.GetButton("Jump");

        action_input = Input.GetButton("Fire1");
    }

    private void FlipSprite()
    {
        if (!isGrounded)
            return;

        if (horizontal_input != 0)
            transform.localScale = new Vector3(horizontal_input, 1, 1);
    }

    public void TouchingLadder(float x)
    {
        if (heroMover.Equals(ladder))
            return;

        if (vertical_input != 0)
        {
            heroMover = ladder;
            heroMover.Init(this, x);
        }
    }

    public void NotTouchingLadder()
    {
        heroMover = land;
    }
}