using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleComponent : MonoBehaviour
{
    [SerializeField] private GameObject fx;
    public void CreateFX() => Destroy(Instantiate(fx, transform.position, Quaternion.identity), 2f);
}
