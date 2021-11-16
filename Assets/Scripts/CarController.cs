using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    private float horizontal;
    private float vertical;

    [SerializeField] WheelCollider frontRightWheelCollider;
    [SerializeField] WheelCollider frontLeftWheelCollider;
    [SerializeField] WheelCollider rearRightWheelCollider;
    [SerializeField] WheelCollider rearLeftWheelCollider;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform rearRightTransform;
    [SerializeField] Transform rearLeftTransform;

    [SerializeField] float acceleration;
    [SerializeField] float maxSteerAngle;

    private float currentAcceleration = 0f;
    private float currentSteerAngle = 0f;

    [SerializeField] float boostSpeed;



    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Acceleration();
        Steering();
        UpdateWheelPosition();
        BoostSpeed();
    }

    void Acceleration()
    {
        currentAcceleration = acceleration * vertical;
        frontRightWheelCollider.motorTorque = currentAcceleration;
        frontLeftWheelCollider.motorTorque = currentAcceleration;
    }

    void Steering()
    {
        currentSteerAngle = maxSteerAngle * horizontal;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
    }

    void UpdateWheelPosition()
    {
        UpdateWheelPosition(frontRightWheelCollider, frontRightTransform);
        UpdateWheelPosition(frontLeftWheelCollider, frontLeftTransform);
        UpdateWheelPosition(rearRightWheelCollider, rearRightTransform);
        UpdateWheelPosition(rearLeftWheelCollider, rearLeftTransform);
    }
    void UpdateWheelPosition(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        transform.position = position;
        transform.rotation = rotation;
    }

    void BoostSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * boostSpeed);
        }
    }
}
