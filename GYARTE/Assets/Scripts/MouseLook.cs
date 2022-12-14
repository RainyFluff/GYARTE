using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity;
    public GameObject orientation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;

        turn.y = Mathf.Clamp(turn.y, -90, 90);

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        orientation.transform.rotation = Quaternion.Euler(0, turn.x, 0);   

        
    }
}
