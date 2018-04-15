using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMainCamera : MonoBehaviour
{
    void Start()
    {
        GameManager.gm.mainCamera = GetComponent<Camera>();
    }
}
