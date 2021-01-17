using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject Camera;
    [SerializeField] bool InvertY = false;
    [SerializeField] float MouseSensitivity = 1;
    [SerializeField] float PlayerWalkSpeed = 10;
    void Start()
    {
        
    }

    void Update()
    {
        UpdateCameraRotation();

        Vector3 Forward = new Vector3(Camera.transform.forward.x, 0, Camera.transform.forward.z);
        if (Input.GetKey("w"))
        {
            transform.position += Forward * Time.deltaTime * PlayerWalkSpeed;
        }
        else if (Input.GetKey("s"))
        {
            transform.position -= Forward * Time.deltaTime * PlayerWalkSpeed;
        }

        Vector3 Right = new Vector3(Camera.transform.right.x, 0, Camera.transform.right.z);
        if (Input.GetKey("d"))
        {
            transform.position += Right * Time.deltaTime * PlayerWalkSpeed;
        }
        else if (Input.GetKey("a"))
        {
            transform.position -= Right * Time.deltaTime * PlayerWalkSpeed;
        }
    }

    private void UpdateCameraRotation()
    {
        // Rotate about global y
        float XDelta = Input.GetAxis("Mouse X") * MouseSensitivity;
        Quaternion q = Quaternion.AngleAxis(XDelta, Vector3.up);
        Camera.transform.rotation = q * Camera.transform.rotation;

        // Rotate about local x
        float YDelta = Input.GetAxis("Mouse Y") * MouseSensitivity;
        if (!InvertY) YDelta = -YDelta;
        Camera.transform.Rotate(new Vector3(YDelta, 0, 0));
    }
}
