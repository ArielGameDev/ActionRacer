using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] float rotation;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, speed);
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, rotation);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
