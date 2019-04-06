using UnityEngine;

public class Ladder : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Hero>().TouchingLadder((int)transform.position.x);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Hero>().NotTouchingLadder();
    }
}
