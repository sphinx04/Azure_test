using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject vc;
    
    void Start()
    {
        EventBus.Subscribe(PlayerEventType.Start, SwitchCams);
        EventBus.Subscribe(PlayerEventType.Finish, SwitchCams);
    }

    void SwitchCams()
    {
        vc.SetActive(!vc.activeSelf);
    }
}
