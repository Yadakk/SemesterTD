using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    //Serialized
    [Header("Rotation")]
    [SerializeField] 
    private float sensitivity = 0.5f;

    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private float maxHorizontalSpeed = 100f;

    [Header("Jumping")]
    [SerializeField]
    private float jumpForce = 10f;

    //Input
    private PlayerMovementActions actions;
    private bool rotateFlag;

    //ComponentReferences
    private Camera cam;
    private Rigidbody rb;

    //Ungrouped
    private LimitedRotation limitedRotation;
    private int collisions;

    //Properties
    public Rigidbody Rigidbody => rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();

        limitedRotation = new(cam.transform, Vector3.left, -90f, 90f);

        actions = new();
        actions.Player.OnJump.started += OnJumpHandler;
        actions.Player.OnRotate.started += OnRotateHandler;
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisions++;
    }

    private void OnCollisionExit(Collision collision)
    {
        collisions--;
    }

    private void FixedUpdate()
    {
        CallMovement();
    }

    private void CallMovement()
    {
        Vector2 direction = actions.Player.OnMove.ReadValue<Vector2>();
        OnMoveHandler(direction);
    }

    private void OnMoveHandler(Vector2 direction)
    {
        PlayerMovementMethods.Move(Rigidbody, direction * moveSpeed, maxHorizontalSpeed);
    }

    private void OnRotateHandler(InputAction.CallbackContext context)
    {
        if (!rotateFlag)
        {
            rotateFlag = true;
            return;
        }

        Vector2 delta = context.ReadValue<Vector2>();
        PlayerMovementMethods.Rotate(transform, delta * sensitivity, limitedRotation);
    }

    private void OnJumpHandler(InputAction.CallbackContext context)
    {
        if (collisions == 0) return;
        PlayerMovementMethods.Jump(Rigidbody, jumpForce);
    }
}
