using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabObject : XRGrabInteractable
{
    [SerializeField] private XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        /*
        grabInteractable.SelectEnter.AddListener(OnGrab);
        grabInteractable.SelectExited.AddListener(OnRelease);
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
