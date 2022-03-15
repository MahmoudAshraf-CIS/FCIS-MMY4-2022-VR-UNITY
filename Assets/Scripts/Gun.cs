using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Gun : MonoBehaviour
{
    public SteamVR_Input_Sources hand;
    public SteamVR_Action_Boolean button;
    public GameObject BulletPrefab;
    public Transform muzzle;
    public float force = 5;
    Rigidbody bulletRb;
    // Update is called once per frame
    void Update()
    {
        if (button.GetStateDown(hand))
        {
            Debug.Log("Shoot");
            GameObject bullet = Instantiate(BulletPrefab, muzzle.position, muzzle.rotation);
            if((bulletRb = bullet.GetComponent<Rigidbody>()) != null)
            {
                bulletRb.AddRelativeForce(0, 0, force);

                Destroy(bullet,2);

            }
        }
    }
}
