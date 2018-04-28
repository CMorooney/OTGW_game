using UnityEngine;

public class WirtController : MonoBehaviour
{
    public float MovementSpeed = 3;

    Direction CurrentDirection = Direction.Down;
    Animator Animator;

    #region Lifecycle

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    //called every frame
    void Update()
    {
        HandleKeyInput();
    }

    #endregion

    public Direction GetCurrentDirection()
    {
        return CurrentDirection;
    }

    void HandleKeyInput()
    {
        var horizontalInput = Input.GetAxisRaw(UnityConstants.HorizontalAxis);
        var verticalInput = Input.GetAxisRaw(UnityConstants.VerticalAxis);

        //move right
        if (horizontalInput > 0)
        {
            CurrentDirection = Direction.Right;

            Animator.SetInteger(AnimationConstants.HorizontalMovement, 1);
            Animator.SetInteger(AnimationConstants.VerticalMovement, 0);

            transform.Translate(new Vector3(horizontalInput * MovementSpeed * Time.deltaTime, 0, 0));
        }

        //move left
        else if (horizontalInput < 0)
        {
            CurrentDirection = Direction.Left;

            Animator.SetInteger(AnimationConstants.HorizontalMovement, -1);
            Animator.SetInteger(AnimationConstants.VerticalMovement, 0);

            transform.Translate(new Vector3(horizontalInput * MovementSpeed * Time.deltaTime, 0, 0));
        }

        //move up
        else if (verticalInput > 0)
        {
            CurrentDirection = Direction.Up;

            Animator.SetInteger(AnimationConstants.HorizontalMovement, 0);
            Animator.SetInteger(AnimationConstants.VerticalMovement, 1);

            transform.Translate(new Vector3(0, verticalInput * MovementSpeed * Time.deltaTime), 0);
        }

        //move down
        else if (verticalInput < 0)
        {
            CurrentDirection = Direction.Down;

            Animator.SetInteger(AnimationConstants.HorizontalMovement, 0);
            Animator.SetInteger(AnimationConstants.VerticalMovement, -1);

            transform.Translate(new Vector3(0, verticalInput * MovementSpeed * Time.deltaTime), 0);
        }
        else
        {
            CurrentDirection = Direction.Idle;

            Animator.SetInteger(AnimationConstants.HorizontalMovement, 0);
            Animator.SetInteger(AnimationConstants.VerticalMovement, 0);
        }
    }
}