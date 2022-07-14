using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CustomJoystick joystick;
    [SerializeField] private float slideSpeed = 5f;
    [SerializeField] private Vector2 borders;

    private float offset;
    private void Start()
    {
        joystick.enabled = false;
        EventBus.Subscribe(PlayerEventType.Start, () =>
        {
            joystick.enabled = true;
        });
        EventBus.Subscribe(PlayerEventType.Finish, () =>
        {
            offset = 0;
            joystick.enabled = false;
        });
    }

    void Update()
    {
        if(!joystick.enabled) return;
        
        offset = transform.position.x + joystick.Horizontal * slideSpeed * Time.deltaTime;
        if (offset > borders.x && offset < borders.y)
        {
            transform.position = new Vector3(offset, transform.position.y, transform.position.z);
            transform.eulerAngles = new Vector3(0, joystick.Horizontal * 30f, 0);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, .1f);
        }
    }
}
