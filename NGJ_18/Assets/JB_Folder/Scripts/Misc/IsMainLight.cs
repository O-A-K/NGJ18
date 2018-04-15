using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMainLight : MonoBehaviour
{
    void Start()
    {
        GameManager.gm.mainLight = GetComponent<Light>();
    }
}
