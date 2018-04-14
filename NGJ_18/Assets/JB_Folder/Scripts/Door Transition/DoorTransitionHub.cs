using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransitionHub : MonoBehaviour
{
    public DoorTransition door1;
    public DoorTransition door2;

    public int sceneIndex;
    


    void Update()
    {
        if (door1.pcReady && door2.pcReady) // if both PCs are ready
        {
            GameManager.gm.GoToScene(sceneIndex);
        }
    }

    public bool IsOtherReady(DoorTransition dt)
    {
        if (dt == door1)
        {
            return door2.pcReady;
        }
        else
        {
            return door1.pcReady;
        }
    }
}
