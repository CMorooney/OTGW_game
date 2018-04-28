using UnityEngine;

public class GregController : MonoBehaviour
{
    public Transform Wirt;

    public WirtController WirtController;

    public float FollowDistance = .6f;

    public float MovementSpeed = 3;

    Animator Animator;
    float LastX;
    float LastY;
    float LastZ;

    void Start()
    {
        Animator = GetComponent<Animator>();
        WirtController = GameObject.FindGameObjectWithTag(GameConstants.WirtName).GetComponent<WirtController>();
    }

    void Update()
    {
        FollowWirt();
    }

    void FollowWirt()
    {
        var direction = WirtController.GetCurrentDirection();

        switch(direction)
        {
            case Direction.Down:
                Animator.SetInteger(AnimationConstants.HorizontalMovement, 0);
                Animator.SetInteger(AnimationConstants.VerticalMovement, 1);

                LastZ = 2;
                LastX = Wirt.position.x;
                LastY = Wirt.position.y + FollowDistance;
                break;

            case Direction.Up:
                Animator.SetInteger(AnimationConstants.HorizontalMovement, 0);
                Animator.SetInteger(AnimationConstants.VerticalMovement, -1);

                LastZ = -1;
                LastX = Wirt.position.x;
                LastY = Wirt.position.y - FollowDistance;
                break;

            case Direction.Right:
                Animator.SetInteger(AnimationConstants.HorizontalMovement, 1);
                Animator.SetInteger(AnimationConstants.VerticalMovement, 0);

                LastZ = 2;
                LastX = Wirt.position.x - FollowDistance;
                LastY = Wirt.position.y;
                break;

            case Direction.Left:
                Animator.SetInteger(AnimationConstants.HorizontalMovement, -1);
                Animator.SetInteger(AnimationConstants.VerticalMovement, 0);

                LastZ = 2;
                LastX = Wirt.position.x + FollowDistance;
                LastY = Wirt.position.y;
                break;

            default:
                Animator.SetInteger(AnimationConstants.HorizontalMovement, 0);
                Animator.SetInteger(AnimationConstants.VerticalMovement, 0);
                break;
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(LastX, LastY, LastZ), .25f);
    }
}