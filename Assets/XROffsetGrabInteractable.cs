using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{
    void Start()
    {
        if (!attachTransform) 
        {
            GameObject attachPoint = new GameObject("Offset Grab Pivot");
            attachPoint.transform.SetParent(transform, false);
            attachTransform = attachPoint.transform;
        }
    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        attachTransform. position = interactor.transform.position;
        attachTransform. rotation = interactor.transform.rotation;

        base.OnSelectEnter(interactor);
    }

  


}