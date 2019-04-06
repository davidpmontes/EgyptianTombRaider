using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private readonly float H_SPEED = 4;
    private readonly float V_SPEED = 4;

    private bool canVerticalFollow;
    private bool canHorizontalFollow;

    private void Start()
    {
        canVerticalFollow = false;
        canHorizontalFollow = true;
    }

    public void SetVerticalFollow(bool value)
    {
        canVerticalFollow = value;
    }

    public void SetHorizontalFollow(bool value)
    {
        canHorizontalFollow = value;
    }

    void Update()
    {
        if (canVerticalFollow)
            VerticalFollow();

        if (canHorizontalFollow)
            HorizontalFollow();
    }

    void HorizontalFollow()
    {
        float distance = Vector2.Distance(new Vector2(transform.position.x, 0),
                                          new Vector2(target.position.x, 0));

        transform.position = Vector3.MoveTowards(transform.position,
                                                 new Vector3(target.position.x, transform.position.y, transform.position.z),
                                                 Time.deltaTime * distance * H_SPEED);
    }

    void VerticalFollow()
    {
        float distance = Vector2.Distance(new Vector2(0, transform.position.y),
                                          new Vector2(0, target.position.y));

        transform.position = Vector3.MoveTowards(transform.position,
                                                 new Vector3(transform.position.x, target.position.y, transform.position.z),
                                                 Time.deltaTime * distance * V_SPEED);
    }
}
