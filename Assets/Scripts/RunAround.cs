using UnityEngine;

public class RunAround : MonoBehaviour, IHeroMover
{
    private Hero hero;
    private Rigidbody2D rb2d;

    private readonly float SPEED_JUMP_INITIAL = 12f;
    private readonly float RAPID_JUMP_SLOWDOWN = 0.7f;
    private readonly float TERMINAL_VELOCITY_Y = -18f;

    private readonly float MAX_WALK_HORIZONTAL = 6.5f;
    private readonly float MAX_RUN_HORIZONTAL = 9f;
    private readonly float ACCELERATION_HORIZONTAL = 17f;
    private readonly float INITIAL_HOLDING_JUMP_SPEED = 0.1f;
    private readonly float HOLDING_SPEED_SLOWDOWN = 0.6f;

    public void Init(Hero hero)
    {
        this.hero = hero;
        this.rb2d = hero.rb2d;
    }

    public void Move()
    {
        Run();
        Jump();
    }

    public void Gravity()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y + -9.8f * 3 * Time.deltaTime);
    }

    private void Run()
    {
        if (Mathf.Abs(hero.horizontal_input) > 0)
            rb2d.velocity = new Vector2(Mathf.MoveTowards(rb2d.velocity.x,
                                                        (hero.action_input ? MAX_RUN_HORIZONTAL : MAX_WALK_HORIZONTAL) * hero.horizontal_input,
                                                        ACCELERATION_HORIZONTAL * Time.deltaTime), rb2d.velocity.y);
        else
        {
            if (hero.isGrounded)
                rb2d.velocity = new Vector2(Mathf.MoveTowards(rb2d.velocity.x, 0,
                                                            ACCELERATION_HORIZONTAL * Time.deltaTime),
                                                            rb2d.velocity.y);
        }
    }

    private void Jump()
    {
        if (hero.jump_input)
        {
            if (hero.canJump)
            {
                hero.canJump = false;
                rb2d.velocity = new Vector2(rb2d.velocity.x, SPEED_JUMP_INITIAL);
                hero.holdingJumpSpeed = INITIAL_HOLDING_JUMP_SPEED;
                hero.isHoldingJump = true;
            }
            else if (hero.isHoldingJump)
            {
                if (rb2d.velocity.y > 0)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x,
                                              rb2d.velocity.y + hero.holdingJumpSpeed);

                    hero.holdingJumpSpeed *= HOLDING_SPEED_SLOWDOWN;
                }
                else
                {
                    hero.isHoldingJump = false;
                }
            }
        }
        else
        {
            if (rb2d.velocity.y > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x,
                                          rb2d.velocity.y * RAPID_JUMP_SLOWDOWN);
            }

            hero.isHoldingJump = false;
        }

        hero.canJump = hero.isGrounded && !hero.jump_input;

        rb2d.velocity = new Vector2(rb2d.velocity.x,
                                  Mathf.Max(rb2d.velocity.y,
                                  TERMINAL_VELOCITY_Y));
    }
}
