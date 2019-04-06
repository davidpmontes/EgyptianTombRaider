using UnityEngine;

public class ClimbLadder : MonoBehaviour, IHeroMover
{
    private Hero hero;
    private Rigidbody2D rb2d;


    private bool isOnLadder;
    private int ladderX;

    private int horizontal_input;
    private int vertical_input;

    private readonly float MAX_CLIMB_SPEED = 20f;
    private readonly float CLIMB_ACCELERATION = 20f;
    private readonly float CENTERING_SPEED = 10f;

    public void Init(Hero hero)
    {
        this.hero = hero;
        this.rb2d = hero.rb2d;
    }

    public void Move()
    {
        Climb();
    }

    public void Gravity()
    {

    }

    private void Climb()
    {
        rb2d.velocity = new Vector2(hero.horizontal_input * 3, hero.vertical_input * 3);

        //if (Mathf.Abs(vertical_input) > 0)
        //{
        //    rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.MoveTowards(rb2d.velocity.y,
        //                                                MAX_CLIMB_SPEED * vertical_input,
        //                                                CLIMB_ACCELERATION * Time.deltaTime));

        //    if (ladderX < transform.position.x)
        //        rb2d.velocity = new Vector2(-Time.deltaTime * CENTERING_SPEED, rb2d.velocity.y);


        //    if (ladderX > transform.position.x)
        //        rb2d.velocity = new Vector2(Time.deltaTime * CENTERING_SPEED, rb2d.velocity.y);
                
        //}
    }
}
