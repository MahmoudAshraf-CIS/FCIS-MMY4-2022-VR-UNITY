using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.VRModuleManagement;

public class Grab : MonoBehaviour
{
    
    Collider[] colliders;

    [SerializeField]
    ViveRoleProperty roleHand;
    ControllerButton gripButton;
    // Update is called once per frame
    void Update()
    {

        if (ViveInput.GetPressDown(roleHand, gripButton)){
            Debug.Log("down");
            colliders = Physics.OverlapSphere(transform.position, 0.1f);
            if (colliders.Length > 0)
            {
                colliders[0].transform.SetParent(this.transform);
                Rigidbody rb = colliders[0].gameObject.GetComponent<Rigidbody>();
                if (rb)
                {
                    rb.useGravity = false;
                    rb.isKinematic = true;
                }
            }
        }
        if (ViveInput.GetPressUp(roleHand, gripButton) && colliders != null && colliders.Length > 0)
        {
            var deviceState = VRModule.GetCurrentDeviceState(roleHand.GetDeviceIndex());
            Debug.Log("velocity: " + deviceState.velocity + " - angolar = " + deviceState.angularVelocity );

            Debug.Log("up");

            colliders[0].transform.SetParent(null);
            Rigidbody rb = colliders[0].gameObject.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
                // apply force that is relative to the controller velocity
                rb.velocity = deviceState.velocity;
                rb.angularVelocity = deviceState.angularVelocity;
            }
        }

    }

     
     
}
