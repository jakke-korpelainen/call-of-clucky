using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour {

    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;
    }

    [SerializeField]
    float speed;
    [SerializeField]
    MouseInput mouseControl;

    private Crosshair _crosshair;
    public Crosshair Crosshair
    {
        get
        {
            return _crosshair ?? (_crosshair = GetComponentInChildren<Crosshair>());
        }
    }

    private MoveController _moveController;
    public MoveController MoveController
    {
        get
        {
            if (_moveController == null)
                _moveController = GetComponent<MoveController>();

            return _moveController;
        }
    }

    private InputController playerInput;
    Vector2 mouseInput;

    void Awake () {
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;
    }
	
	void Update () {
        Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        MoveController.Move(direction);

        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / mouseControl.Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / mouseControl.Damping.y);

        transform.Rotate(Vector3.up * mouseInput.x * mouseControl.Sensitivity.x);

        Crosshair.LookHeight(mouseInput.y * mouseControl.Sensitivity.y);
    }
}
