using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private Button startButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject WinPanel;
    
    
    private int count;

    private void Start()
    {
        startButton.gameObject.SetActive(true);
        WinPanel.SetActive(false);
        
        startButton.onClick.AddListener(() =>
        {
            EventBus.Publish(PlayerEventType.Start);
            startButton.gameObject.SetActive(false);
        });
        restartButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        
        EventBus.Subscribe(PlayerEventType.Collect, () => SetCounter(++count));
        EventBus.Subscribe(PlayerEventType.Finish, () => WinPanel.SetActive(true));
        SetCounter(count);
    }

    private void SetCounter(int value)
    {
        counter.text = "x " + value;
    }
}
