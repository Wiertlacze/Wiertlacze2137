using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float followSpeed = 1.0f;

    private void FixedUpdate()
    {
        var desiredPosition = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed);
        
        transform.LookAt(playerTransform);
    }
}
