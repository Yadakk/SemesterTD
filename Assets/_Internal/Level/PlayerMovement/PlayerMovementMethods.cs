using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerMovementMethods
{
    public static void Move(Rigidbody rigidbody, Vector2 direction, float maxSpeed)
    {
        Vector3 rotatedDirection = rigidbody.transform.rotation * new Vector3(direction.x, 0f, direction.y);
        rigidbody.AddForce(rotatedDirection * rigidbody.mass, ForceMode.Impulse);

        Vector3 horizontalVelocity = rigidbody.velocity;
        horizontalVelocity.y = 0f;

        if (horizontalVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = horizontalVelocity.normalized * maxSpeed;
            limitedVelocity.y = rigidbody.velocity.y;

            rigidbody.velocity = limitedVelocity;
        }
    }

    public static void Rotate(Transform playerTransform, Vector2 delta, LimitedRotation cameraLimitedRotation)
    {
        playerTransform.Rotate(new(0f, delta.x, 0f));
        cameraLimitedRotation.Rotate(delta.y);
    }

    public static void Jump(Rigidbody rb, float force)
    {
        rb.AddForce(force * rb.mass * Vector3.up);
    }
}
