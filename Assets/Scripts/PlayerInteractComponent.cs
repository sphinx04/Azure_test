using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInteractComponent : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        EventBus.Subscribe(PlayerEventType.Run, Run);
        EventBus.Subscribe(PlayerEventType.Stop, Stop);
    }

    private void OnTriggerEnter(Collider other)
    {
        var collectible = other.GetComponent<CollectibleComponent>();
        var finish = other.GetComponent<FinishComponent>();
        if (collectible)
        {
            EventBus.Publish(PlayerEventType.Collect);
            collectible.CreateFX();
            collectible.gameObject.SetActive(false);
        }
        else if (finish)
        {
            Stop();
            finish.StartFX();
            EventBus.Publish(PlayerEventType.Finish);
        }
    }

    private void Run()
    {
        animator.SetTrigger("Run");
    }

    private void Stop()
    {
        animator.SetTrigger("Idle");
    }
}
