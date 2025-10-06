using UnityEngine;

public class PlayerMovement
{
    public void Move(float vertMoveF, float moveSpeed, Rigidbody playerRb)
    {
        //playerRb.linearVelocityX = vertMoveF * moveSpeed;
        playerRb.linearVelocity = new Vector3(vertMoveF * moveSpeed, 0, 0);
    }
}
