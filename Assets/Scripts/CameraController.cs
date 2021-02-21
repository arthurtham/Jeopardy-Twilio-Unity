using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    //private Transform m_transform;
    public bool rotateLeft;
    public bool rotateRight; 

    private float rotationValue;

    void Start()
    {
        //m_transform = this.gameObject.transform;
        rotationValue = 0.05f;
    }

    public void RotateCameraLeft() {
        rotateRight = false;
        rotateLeft = true;
    }

    public void RotateCameraRight() {
        rotateRight = true;
        rotateLeft = false;
    }

    public void StopRotation() {
        rotateRight = false;
        rotateLeft = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(
            transform.position.x + 0.25f,
            transform.position.y + 0.05f,
            transform.position.z + (rotateLeft ? -0.05f : 0.00f)
        );

        if (rotateRight && (rotationValue < 0.05f)) {
            rotationValue += 0.0005f;
        } else if (rotateLeft && (rotationValue > -0.05f)) {
            rotationValue -= 0.0005f;
        } else {
            if (rotationValue > 0.0f) {
                rotationValue -= 0.0005f;
            } else if (rotationValue < 0.0f) {
                rotationValue += 0.0005f;
            }
        }

        transform.Rotate(0.0f, rotationValue, 0.0f, Space.Self);

    }
}
