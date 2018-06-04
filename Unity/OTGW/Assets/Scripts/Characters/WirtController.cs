using System.Collections.Generic;
using UnityEngine;

public class WirtController : MonoBehaviour
{
    public float MovementSpeed = 3;

	public DialogManager DialogManager;

    Direction CurrentDirection = Direction.Down;
    Animator Animator;
    Queue<Transform> PositionQueue;

    #region Lifecycle

    void Start()
    {
        Animator = GetComponent<Animator>();
        PositionQueue = new Queue<Transform>();
    }

    void Update()
    {
		HandleMovement();
		CheckForDialog();

        PositionQueue.Enqueue(transform);
    }

    #endregion

    public Direction GetCurrentDirection()
    {
        return CurrentDirection;
    }

    public Vector3 GetLastPosition()
    {
        if (PositionQueue != null && PositionQueue.Count > 0)
        {
            return PositionQueue.Dequeue().position;
        }

        return Vector3.zero;
    }

    void CheckForDialog()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			DialogManager.RequestRockFact();
		}
	}

    void HandleMovement()
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