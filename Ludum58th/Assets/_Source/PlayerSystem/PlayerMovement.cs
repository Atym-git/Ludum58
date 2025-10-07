using UnityEngine;

public class PlayerMovement
{
    public void Move(float vertMoveF, float moveSpeed, Rigidbody playerRb, Transform characterTransform)
    {
        if (vertMoveF > 0)
        {
            float characterRotYRight = 180;
            characterTransform.localRotation = Quaternion.Euler(0, characterRotYRight, 0);
        }
        else if (vertMoveF < 0)
        {
            float characterRotYLeft = 0;
            characterTransform.localRotation = Quaternion.Euler(0, characterRotYLeft, 0);
        }
        playerRb.linearVelocity = new Vector3(vertMoveF * moveSpeed, 0, 0);
        
    }
}
