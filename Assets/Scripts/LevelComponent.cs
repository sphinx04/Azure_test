using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComponent : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10;

    private float currentSpeed;
    private float targetSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Subscribe(PlayerEventType.Run, Move);
        EventBus.Subscribe(PlayerEventType.Stop, Stop);
        EventBus.Subscribe(PlayerEventType.Finish, Stop);
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, .2f);
        transform.Translate(0,0, -currentSpeed * Time.deltaTime);
    }

    void Move() => targetSpeed = maxSpeed;
    void Stop() => targetSpeed = 0;
}
