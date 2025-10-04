using UnityEngine;

public class PlayerMovement
{
    public void Move(float vertMoveF, float moveSpeed, Rigidbody2D playerRb)
    {
        //playerRb.linearVelocity = new Vector2 (vertMoveF * moveSpeed, 0);
        //playerRb.linearVelocityX = vertMoveF * moveSpeed;
        Transform playerTransform = playerRb.transform;
        playerTransform.position += new Vector3(vertMoveF * moveSpeed, 0, 0);
    }
}
