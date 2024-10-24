using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabAndDrop : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody cubeRigidbody;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        cubeRigidbody = GetComponent<Rigidbody>();

        // Disable gravity while grabbing
        //grabInteractable.onSelectEnter.AddListener(OnGrab);
        // Enable gravity on release
        //grabInteractable.onSelectExit.AddListener(OnRelease);
    }
    /*
    private void OnGrab(SelectEnterEventArgs args)
    {
        cubeRigidbody.isKinematic = true;  // Stop the cube from falling while held
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        cubeRigidbody.isKinematic = false;  // Let the cube fall after releasing
        cubeRigidbody.useGravity = true;    // Ensure gravity is enabled
    }*/
}
