using UnityEngine;

public class ClimbLadder : MonoBehaviour, IHeroMover
{
    private Hero hero;
    private Rigidbody2D rb2d;

    private float ladderX;

    private readonly float MAX_CLIMB_SPEED = 20f;
    private readonly float CLIMB_ACCELERATION = 20f;
    private readonly float CENTERING_SPEED = 10f;

    public void Init(Hero hero)
    {
        this.hero = hero;
        this.rb2d = hero.rb2d;
    }

    public void Init(Hero hero, float x)
    {
        ladderX = x;
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
        if (hero.horizontal_input == 0)
        {
            if (Mathf.Abs(hero.transform.position.x - ladderX) < 0.1f)
            {
                rb2d.velocity = new Vector2(0, hero.vertical_input * 3);
                return;
            }

            if (hero.transform.position.x > ladderX)
            {
                rb2d.velocity = new Vector2(-2f * Mathf.Abs(hero.vertical_input), hero.vertical_input * 3);
            }
            else
            {
                rb2d.velocity = new Vector2(2f * Mathf.Abs(hero.vertical_input), hero.vertical_input * 3);
            }
        }
        else
        {
            rb2d.velocity = new Vector2(hero.horizontal_input * 3, hero.vertical_input * 3);
        }
    }
}
