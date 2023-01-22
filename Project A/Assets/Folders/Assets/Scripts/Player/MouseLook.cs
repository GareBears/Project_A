using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 100f; //Mouse Sense
    public Transform playerbody; //Player
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Locks the Cursor during Play
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime; //Inputs Mouse X
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime; //Inputs Mouse Y

        xRotation -= mouseY; //Mouse Rotation Calc
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerbody.Rotate(Vector3.up * mouseX);
    }
}
