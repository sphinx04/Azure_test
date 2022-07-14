using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishComponent : MonoBehaviour
{
    [SerializeField] private GameObject FX;
    
    public void StartFX()
    {
        FX.SetActive(true);
    }
}
