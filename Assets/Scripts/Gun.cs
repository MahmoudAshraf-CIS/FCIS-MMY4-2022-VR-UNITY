using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using HTC.UnityPlugin.Vive;

public class Gun : MonoBehaviour
{
    /*public SteamVR_Input_Sources hand;
    public SteamVR_Action_Boolean button;*/


    public GameObject BulletPrefab;
    public Transform muzzle;
    public float force = 5;
    Rigidbody bulletRb;

    public LayerMask mask;
    // Update is called once per frame
    void Update()
    {
        /*if (button.GetStateDown(hand))*/


        // the gun was using the bullet for collision
        /*if(ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Trigger))
        {
            Debug.Log("Shoot");
            GameObject bullet = Instantiate(BulletPrefab, muzzle.position, muzzle.rotation);
            if((bulletRb = bullet.GetComponent<Rigidbody>()) != null)
            {
                bulletRb.AddRelativeForce(0, 0, force);

                Destroy(bullet,2);

            }
        }*/

        // using the physics raycast

        if (ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Trigger))
        {

            RaycastHit hit;
            if (Physics.Raycast(muzzle.position, muzzle.forward, out hit, 100, mask))
            {
                Debug.Log(hit.transform.gameObject,hit.transform);
                Target t = hit.transform.gameObject.GetComponent<Target>();
                if (t)
                    t.ApplyHit();
            }


        }

}
}
