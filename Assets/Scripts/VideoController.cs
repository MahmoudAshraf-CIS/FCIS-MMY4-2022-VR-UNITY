using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public ControllerButton gripButton;
    public HandRole roleHand;

    public Button _seekBack, _play, _pause,_stop, _seekForward;
    public Slider vpSlider;

    public VideoPlayer vp;

    bool sliderOverrideTime = false;
    // Start is called before the first frame update
    void Start()
    {
        // Regestering each button click event callback 
        _seekBack.onClick.AddListener(SeekBackIsDown);
        _play.onClick.AddListener(PlayIsDown);
        _pause.onClick.AddListener(PauseIsDown);
        _stop.onClick.AddListener(StopIsDown);
        _seekForward.onClick.AddListener(SeekForwardIsDown);

        _play.gameObject.SetActive(false);

        if (!vp && vp.clip != null)
        {
            Debug.LogError("looks like the video player reference is not set correctly! please make sure the video has a vlid source and the reference is set in the editor!");
            return;
        }
        vp.Play();

        

    }

    public void OnSliderDragBegin()
    {
        sliderOverrideTime = true;
    }

    public void OnSliderGradEnd()
    {
        sliderOverrideTime = false;

    }

    void SeekBackIsDown()
    {
        vp.Pause();

        // here set the video time
        vp.time = (vp.time - 10)<0 ? 0 : vp.time - 10;

        vp.Play();
    }

    void SeekForwardIsDown()
    {
        vp.Pause();

        // here set the video time
        vp.time = (vp.time + 10) > vp.clip.length ? 0 : vp.time + 10;

        vp.Play();
    }

    void PlayIsDown()
    {
        vp.Play();
        _play.gameObject.SetActive(false);
        _pause.gameObject.SetActive(true);
    }

    void PauseIsDown()
    {
        vp.Pause();
        _play.gameObject.SetActive(true);
        _pause.gameObject.SetActive(false);
    }

    void StopIsDown()
    {
        PauseIsDown();
        vp.Stop();

        ViveInput.TriggerHapticVibration(roleHand);
    }


    // Update is called once per frame
    void Update()
    {
        // Debug.Log(ViveInput.GetAxis(HandRole.RightHand, ControllerAxis.JoystickX, false) + " , " + ViveInput.GetAxis(HandRole.RightHand, ControllerAxis.JoystickY, false));
        Debug.Log(vp.time);
        
        if (!sliderOverrideTime)
            vpSlider.value = (float)(vp.time / vp.length);
        else
            vp.time = vp.length * vpSlider.value;

    }


}
