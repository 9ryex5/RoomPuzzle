using UnityEngine;

public class Character : MonoBehaviour
{
    public float timeToMove;

    private Vector3 movementTarget;
    private float movementTimer;
    private bool isMoving;

    private void Start()
    {
        movementTarget = transform.position;
    }

    private void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKey(KeyCode.UpArrow)) UpdateMovementTarget(Vector2.up);
            if (Input.GetKey(KeyCode.DownArrow)) UpdateMovementTarget(Vector2.down);
            if (Input.GetKey(KeyCode.LeftArrow)) UpdateMovementTarget(Vector2.left);
            if (Input.GetKey(KeyCode.RightArrow)) UpdateMovementTarget(Vector2.right);
        }
        else
        {
            movementTimer += Time.deltaTime;
            movementTimer = Mathf.Min(movementTimer, timeToMove);
        }

        Move();

        if (movementTimer == timeToMove)
        {
            isMoving = false;
            movementTimer = 0;
        }
    }

    private void UpdateMovementTarget(Vector2 _movement)
    {
        movementTarget += new Vector3(_movement.x, 0, _movement.y);
        isMoving = true;
    }

    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, movementTarget, movementTimer / timeToMove);
    }
}
