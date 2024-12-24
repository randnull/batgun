using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour {
    public float walkingSpeed = 3.0f;
    public float runningSpeed = 5.0f;
    public float crouchingSpeed = 1.0f;
    public float jumpSpeed = 6.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 90.0f;
    public float standHeight = 1.75f;
    public float crouchHeight = 0.8f;
    public float crouchTime = 0.25f;
    public Vector3 standCenter = Vector3.zero;
    public Vector3 crouchCenter = new Vector3(0, 0.4f, 0);

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool isRunning = false;

    public bool crouchAnimation = false;
    public bool isCrouching = false;

    [HideInInspector]
    public bool canMove = true;

    [HideInInspector]
    public float currentSpeed = 0.0f;

    void Start() {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        isRunning = characterController.isGrounded ? Input.GetKey(KeyCode.LeftShift) : isRunning;
        float movementDirectionY = moveDirection.y;
        currentSpeed = isCrouching ? (!characterController.isGrounded ? currentSpeed : crouchingSpeed) : (isRunning ? runningSpeed : walkingSpeed);
        moveDirection = canMove ? currentSpeed * Vector3.ClampMagnitude((forward * Input.GetAxis("Vertical")) + (right * Input.GetAxis("Horizontal")), 1.0f) : Vector3.zero;

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded) {
            moveDirection.y = jumpSpeed;
        } else {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded) {
            if ((characterController.collisionFlags & CollisionFlags.Above) != 0) {
                moveDirection.y = 0;
            }
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !crouchAnimation) {
            StartCoroutine(CrouchStand());
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove) {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    IEnumerator CrouchStand() {
        if (isCrouching && Physics.Raycast(playerCamera.transform.position, Vector3.up, 1f)) yield break;

        crouchAnimation = true;

        float passedTime = 0;
        float targetHeight = isCrouching ? standHeight : crouchHeight;
        float currentHeight = characterController.height;
        Vector3 targetCenter = isCrouching ? standCenter : crouchCenter;
        Vector3 currentCenter = characterController.center;

        while(passedTime < crouchTime) {
            characterController.height = Mathf.Lerp(currentHeight, targetHeight, passedTime / crouchTime);
            characterController.center = Vector3.Lerp(currentCenter, targetCenter, passedTime / crouchTime);
            passedTime += Time.deltaTime;
            yield return null;
        }

        characterController.height = targetHeight;
        characterController.center = targetCenter;

        isCrouching = !isCrouching;

        crouchAnimation = false;
    }
}