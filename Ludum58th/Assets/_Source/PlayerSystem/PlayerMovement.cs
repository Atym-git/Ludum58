using UnityEngine;

public class PlayerMovement
{
    public void Move(float vertMoveF, float moveSpeed, Rigidbody2D playerRb)
    {
        playerRb.linearVelocityX = vertMoveF * moveSpeed;
    }
}
