using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float Vertical { get; set; }
    public float Horizontal { get; set; }
    public Vector2 MouseInput { get; set; }

    public bool Fire1 { get; set; }

    public bool Reload { get; set; }

    void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        Fire1 = Input.GetButton("Fire1");
        Reload = Input.GetKey(KeyCode.R);
    }
}
