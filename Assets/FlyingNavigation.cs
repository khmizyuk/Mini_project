using UnityEngine;

public class FlyingNavigation : MonoBehaviour
{
    public float speed = 5.0f; // Speed of flying
    public float verticalSpeed = 2.0f; // Speed of flying upwards/downwards
    private Vector2 touchpadInput;

    void Update()
    {
        // Detect touchpad input
        touchpadInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Forward and backward movement (Y axis of touchpad)
        Vector3 forwardMovement = transform.forward * touchpadInput.y * speed * Time.deltaTime;

        // Side-to-side (X axis of touchpad)
        Vector3 strafeMovement = transform.right * touchpadInput.x * speed * Time.deltaTime;

        // Combine movements
        Vector3 movement = forwardMovement + strafeMovement;

        // Apply movement to camera rig (or player object)
        transform.position += movement;

        // Optional: Handle vertical movement for flying up or down
        // if (Input.GetButton("Jump"))
        // {
        //     transform.position += Vector3.up * verticalSpeed * Time.deltaTime; // Fly up
        // }
        // else if (Input.GetButton("Crouch"))
        // {
        //     transform.position += Vector3.down * verticalSpeed * Time.deltaTime; // Fly down
        // }
    }
}
