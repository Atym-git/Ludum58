using UnityEngine;

public class PlayerMovement
{
    public void Move(float vertMoveF, float moveSpeed, Rigidbody playerRb, Transform characterTransform)
    {
        //playerRb.linearVelocityX = vertMoveF * moveSpeed;
        playerRb.linearVelocity = new Vector3(vertMoveF * moveSpeed, 0, 0);
        float rotY = characterTransform.rotation.eulerAngles.y;
        if (moveSpeed == 1)
        {
            characterTransform.Rotate(0, 180, 0);
        }
        
        if (moveSpeed == -1)
        {
            characterTransform.Rotate(0, 180, 0);
        }
    }
}
