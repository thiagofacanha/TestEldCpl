using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public EldInputActions inputActions;
    public Rigidbody rigidBody;
    public GameObject player;
    public float speed = 15;
    private Vector3 movementVector = Vector3.zero;
    private float rotateValueY = 0f;
    private float rotateValueX = 0f;
    public float rotateSensitivity = 10f;
    public const float MAX_ROTATE_Y_VALUE = 30;
    public const float MIN_ROTATE_Y_VALUE = -30f;

    private void Awake()
    {
        inputActions = new EldInputActions();
        rigidBody = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.PlayerInput.Move.started += OnMovementPerformed;
        inputActions.PlayerInput.Move.performed += OnMovementPerformed;
        inputActions.PlayerInput.Move.canceled += OnMovementPerformed;
        inputActions.PlayerInput.Camera.performed += OnRotationPerformed;
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.PlayerInput.Move.performed -= OnMovementPerformed;
        inputActions.PlayerInput.Camera.performed -= OnRotationPerformed;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() {
        rigidBody.transform.rotation = Quaternion.Euler(rotateValueY, rotateValueX, 0);
        //player.transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, 1);
        rigidBody.velocity = movementVector * speed;
    }

        // Update is called once per frame
        void Update()
    {
        
    }
    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        Vector3 tempMovementVector = context.ReadValue<Vector3>();
        Vector3 foward = player.transform.forward;
        Vector3 side = player.transform.right;
        foward.y = 0;
        side.y = 0;
        foward = foward.normalized;
        side = side.normalized;


        Vector3 fowardRelative = tempMovementVector.z * foward;
        Vector3 sideRelative = tempMovementVector.x* side;
        movementVector = fowardRelative + sideRelative;
        print("x: " + movementVector.x + " y: " + movementVector.z);
    }

    private void OnRotationPerformed(InputAction.CallbackContext context)
    {
        float mouseX = context.ReadValue<Vector2>().x;
        float mouseY = context.ReadValue<Vector2>().y;
    


        rotateValueY += mouseY * -1;
        if(rotateValueY >= MAX_ROTATE_Y_VALUE)
        {
            rotateValueY = MAX_ROTATE_Y_VALUE;
        } else if(rotateValueY<= MIN_ROTATE_Y_VALUE)
        {
            rotateValueY = MIN_ROTATE_Y_VALUE;
        }
        rotateValueX += mouseX;

        print("rotate x: " + rotateValueX + " rotate y: " + rotateValueY);

    }
}
