using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    public ControllerButton gripButton;
    public HandRole roleHand;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ViveInput.GetAxis(HandRole.RightHand, ControllerAxis.JoystickX, false) + " , " + ViveInput.GetAxis(HandRole.RightHand, ControllerAxis.JoystickY, false));


    }
}
