using UnityEngine;

public class WirtController : MonoBehaviour
{
    public float MovementSpeed = 3;

    Animator Animator;

	void Start()
	{
        Animator = GetComponent<Animator>();
	}

	//called every frame
	void Update()
    {
        HandleKeyInput();
    }

    void HandleKeyInput()
    {
        var horizontalInput = Input.GetAxisRaw(UnityConstants.HorizontalAxis);
        var verticalInput = Input.GetAxisRaw(UnityConstants.VerticalAxis);

        if (horizontalInput > 0)
        {
            Debug.Log("Set H move to 1");
            Animator.SetInteger(AnimationConstants.HorizontalMovement, 1);
            Animator.SetInteger(AnimationConstants.VerticalMovement, 0);

            transform.Translate(new Vector3(horizontalInput * MovementSpeed * Time.deltaTime, 0, 0));
        }
        else if (horizontalInput < 0)
        {
            Debug.Log("Set H move to -1");
            Animator.SetInteger(AnimationConstants.HorizontalMovement, -1);
            Animator.SetInteger(AnimationConstants.VerticalMovement, 0);

            transform.Translate(new Vector3(horizontalInput * MovementSpeed * Time.deltaTime, 0, 0));
        }
        else if (verticalInput > 0)
        {
            Debug.Log("Set V move to 1");
            Animator.SetInteger(AnimationConstants.HorizontalMovement, 0);
            Animator.SetInteger(AnimationConstants.VerticalMovement, 1);

            transform.Translate(new Vector3(0, verticalInput * MovementSpeed * Time.deltaTime), 0);
        }
        else if (verticalInput < 0)
        {
            Debug.Log("Set V move to -1");
            Animator.SetInteger(AnimationConstants.HorizontalMovement, 0);
            Animator.SetInteger(AnimationConstants.VerticalMovement, -1);

            transform.Translate(new Vector3(0, verticalInput * MovementSpeed * Time.deltaTime), 0);
        }
        else
        {
            Debug.Log("Set all to 0");
            Animator.SetInteger(AnimationConstants.HorizontalMovement, 0);
            Animator.SetInteger(AnimationConstants.VerticalMovement, 0);
        }
    }
}