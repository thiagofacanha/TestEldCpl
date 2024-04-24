using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public InputManager inputManager;
    public Rigidbody rigidBody;
    public float speed = 15;
    private Vector2 movementVector = Vector2.zero;


    private void Awake()
    {
        inputManager = GetComponent<InputManager>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  /*      float foward = inputManager.inputActions.PlayerInput.Move.ReadValue<float>();
        float side = inputManager.inputActions.PlayerMovements.Foward.ReadValue<float>();
        Vector3 move = (transform.right * side + transform.forward * foward) * speed;
        rigidBody.velocity = new Vector3(foward..x, 0f, move.z);*/
    }

    private void OnEnable()
    {
        inputManager.enabled = true;
    }

    private void OnDisable()
    {
        inputManager.enabled = false;
    }
}
