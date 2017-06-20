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

    public bool IsWalking { get; set; }

    public bool IsSprinting { get; set; }

    public bool IsCrouched { get; set; }

    void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        Fire1 = Input.GetButton("Fire1");
        Reload = Input.GetKey(KeyCode.R);

        IsSprinting = Input.GetKey(KeyCode.LeftShift);
        IsWalking = Input.GetKey(KeyCode.LeftAlt);
        IsCrouched = Input.GetKey(KeyCode.C);
    }
}
