using UnityEngine;

public class PlayerMovement
{
    public void Move(float vertMoveF, float moveSpeed, Rigidbody2D playerRb)
    {
        playerRb.linearVelocity = new Vector2 (vertMoveF, 0) * moveSpeed;
    }
}
