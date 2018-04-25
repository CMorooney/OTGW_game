using UnityEngine;

public class GregController : MonoBehaviour
{
    public Transform Wirt;

    public WirtController WirtController;

    public float FollowDistance = .6f;

    public float MovementSpeed = 3;

    Animator Animator;

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

        var xPosition = 0f;
        var yPosition = 0f;
        var zPosition = 0f;

        switch(direction)
        {
            case Direction.Down:
                zPosition = 1;
                xPosition = Wirt.position.x;
                yPosition = Wirt.position.y + FollowDistance;
                break;

            case Direction.Up:
                zPosition = -1;
                xPosition = Wirt.position.x;
                yPosition = Wirt.position.y - FollowDistance;
                break;

            case Direction.Right:
                zPosition = 1;
                xPosition = Wirt.position.x - FollowDistance;
                yPosition = Wirt.position.y;
                break;

            case Direction.Left:
                zPosition = 1;
                xPosition = Wirt.position.x + FollowDistance;
                yPosition = Wirt.position.y;
                break;
        }

        transform.position = new Vector3(xPosition, yPosition, zPosition);
    }

    void Animate()
    {
        
    }
}