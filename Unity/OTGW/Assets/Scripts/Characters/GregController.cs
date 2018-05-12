using UnityEngine;

public class GregController : MonoBehaviour
{
    public Transform Wirt;

    public WirtController WirtController;

    public float FollowDistance = .6f;

    public int FollowDelay = 5;

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

        var tryPosition = WirtController.GetLastPosition();
        var newPosition = tryPosition == Vector3.zero ? transform.position : tryPosition;

        switch(direction)
        {
            case Direction.Down:
                Animator.SetInteger(AnimationConstants.HorizontalMovement, 0);
                Animator.SetInteger(AnimationConstants.VerticalMovement, 1);

                LastZ = 2;
                LastX = newPosition.x;
                LastY = newPosition.y + FollowDistance;
                break;

            case Direction.Up:
                Animator.SetInteger(AnimationConstants.HorizontalMovement, 0);
                Animator.SetInteger(AnimationConstants.VerticalMovement, -1);

                LastZ = -1;
                LastX = newPosition.x;
                LastY = newPosition.y - FollowDistance;
                break;

            case Direction.Right:
                Animator.SetInteger(AnimationConstants.HorizontalMovement, 1);
                Animator.SetInteger(AnimationConstants.VerticalMovement, 0);

                LastZ = 2;
                LastX = newPosition.x - FollowDistance;
                LastY = newPosition.y;
                break;

            case Direction.Left:
                Animator.SetInteger(AnimationConstants.HorizontalMovement, -1);
                Animator.SetInteger(AnimationConstants.VerticalMovement, 0);

                LastZ = 2;
                LastX = newPosition.x + FollowDistance;
                LastY = newPosition.y;
                break;

            default:
                Animator.SetInteger(AnimationConstants.HorizontalMovement, 0);
                Animator.SetInteger(AnimationConstants.VerticalMovement, 0);
                break;
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(LastX, LastY, LastZ), .25f);
    }
}