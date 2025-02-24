using UnityEngine;
using UnityEngine.EventSystems; // Add this namespace for UI detection

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // The car object to orbit around
    public float distance = 5.0f; // Distance from the car
    public float xSpeed = 120.0f; // Horizontal rotation speed
    public float ySpeed = 120.0f; // Vertical rotation speed

    public float yMinLimit = -20f; // Minimum vertical angle
    public float yMaxLimit = 80f; // Maximum vertical angle

    public float smoothTime; // Smooth damping time
    public float zoomSpeed = 2f; // Zoom speed for touch input

    private float x = 0.0f;
    private float y = 0.0f;
    private float xVelocity = 0f;
    private float yVelocity = 0f;
    private float currentDistance;
    private float desiredDistance;

    private bool isRotating = false; // Track if the camera is being rotated

    void Start()
    {
        Time.timeScale = 1f;
        // Initialize camera rotation angles
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Initialize distance
        currentDistance = distance;
        desiredDistance = distance;
    }

    void LateUpdate()
    {
        if (target)
        {
            // Handle input (mouse or touch)
            HandleInput();

            // Clamp vertical angle to avoid flipping
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            // Smoothly interpolate rotation and distance
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomSpeed);

            // Calculate position
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -currentDistance) + target.position;

            // Apply rotation and position to the camera
            transform.rotation = rotation;
            transform.position = position;
        }
    }

    private void HandleInput()
    {
        // Check if the pointer is over a UI element
        if (IsPointerOverUIElement())
        {
            isRotating = false;
            return; // Skip rotation if interacting with UI
        }

        if (Application.isMobilePlatform)
        {
            // Touch input for Android
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Touch touch = Input.GetTouch(0);

                // Normalize touch delta for consistent sensitivity
                float deltaX = touch.deltaPosition.x / Screen.width * xSpeed;
                float deltaY = touch.deltaPosition.y / Screen.height * ySpeed;

                // Smoothly rotate based on touch delta
                x = Mathf.SmoothDampAngle(x, x + deltaX, ref xVelocity, smoothTime);
                y = Mathf.SmoothDampAngle(y, y - deltaY, ref yVelocity, smoothTime);

                isRotating = true;
            }
            else
            {
                isRotating = false;
            }
        }
        else
        {
            // Mouse input for PC
            if (Input.GetMouseButton(0)) // Left mouse button held down
            {
                float deltaX = Input.GetAxis("Mouse X") * xSpeed * 0.1f;
                float deltaY = Input.GetAxis("Mouse Y") * ySpeed * 0.1f;

                // Smoothly rotate based on mouse delta
                x = Mathf.SmoothDampAngle(x, x + deltaX, ref xVelocity, smoothTime);
                y = Mathf.SmoothDampAngle(y, y - deltaY, ref yVelocity, smoothTime);

                isRotating = true;
            }
            else
            {
                isRotating = false;
            }
        }
    }

    // Clamp the vertical angle to avoid flipping
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }

    // Check if the pointer is over a UI element
    private bool IsPointerOverUIElement()
    {
        if (EventSystem.current == null)
            return false;

        // Check for mouse input
        if (Application.isEditor || !Application.isMobilePlatform)
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
        // Check for touch input
        else
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(i).fingerId))
                    return true;
            }
        }
        return false;
    }
}