using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public Transform cameraTransform;

    public float normalSpeed;
    public float fastSpeed;
    public float movementSpeed;
    public float movementTime;
    public float horizontal;
    public float vertical;
    public float shift;
    public float rotate;
    public float zoom;
    public float rotationAmount;
    public Vector3 xMinZoom;
    public Vector3 yMinZoom;
    public Vector3 zMinZoom;
    public Vector3 xMaxZoom;
    public Vector3 yMaxZoom;
    public Vector3 zMaxZoom;
    public Vector3 zoomAmount;

    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 newZoom;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public Vector3 rotateStartPosition;
    public Vector3 rotateCurrentPosition;

    public Vector3 xMinLimit;
    public Vector3 xMaxLimit;
    public Vector3 yMinLimit;
    public Vector3 yMaxLimit;
    public Vector3 zMinLimit;
    public Vector3 zMaxLimit;
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    void Update()
    {
        HandleMovementInput();

        HandleMouseInput();

        Limiter();
    }

    void Limiter()
    {
        //limits how far you can zoom in and out.
        cameraTransform.position = new Vector3(
        Mathf.Clamp(cameraTransform.position.x, xMinZoom.x, xMaxZoom.x),
        Mathf.Clamp(cameraTransform.position.y, yMinZoom.y, yMaxZoom.y),
        Mathf.Clamp(cameraTransform.position.z, zMinZoom.z, zMaxZoom.z));

        //limits how far the camera can go.
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, xMinLimit.x, xMaxLimit.x),
        Mathf.Clamp(transform.position.y, yMinLimit.y, yMaxLimit.y),
        Mathf.Clamp(transform.position.z, zMinLimit.z, zMaxLimit.z));
    }

    void HandleMouseInput()
    {
        //Allows the player to zoom in and out with the mouse wheel.
        if (Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }

        //Allows for moving the camera around by dragging with the mouse.
        if (Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragStartPosition = ray.GetPoint(entry);
            }
        }
        if (Input.GetMouseButton(0)) 
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragCurrentPosition = ray.GetPoint(entry);

                newPosition = transform.position + dragStartPosition - dragCurrentPosition;
            }
        }

        //Allows the player to rotate the camera by holding and dragging with the middle mouse button.
        if (Input.GetMouseButtonDown(2))
        {
            rotateStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(2))
        {
            rotateCurrentPosition = Input.mousePosition;

            Vector3 difference = rotateStartPosition - rotateCurrentPosition;

            rotateStartPosition = rotateCurrentPosition;

            newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
        }
    }

    void HandleMovementInput()
    {
        //Allows the player to increase the movement speed of the camera for as long as they hold down left shift.
        shift = Input.GetAxis("Shift");

        if (shift == 1)
        {
            movementSpeed = fastSpeed;
        }
        else
        {
            movementSpeed = normalSpeed;
        }

        //Allows the player to move around with either the wasd keys or the arrow keys.

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (vertical > 0)
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if (vertical < 0)
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if (horizontal > 0)
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (horizontal < 0)
        {
            newPosition += (transform.right * -movementSpeed);
        }


        //Allows the player to rotate using the Q and E keys.
        rotate = Input.GetAxis("Rotation");

        if (rotate > 0)
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (rotate < 0)
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }

        //Allows the player to zoom in and out with the R and F keys.
        zoom = Input.GetAxis("Zoom");

        if (zoom > 0)
        {
            newZoom += zoomAmount;
        }
        if (zoom < 0)
        {
            newZoom -= zoomAmount;
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
    }
}
