using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransitionHub : MonoBehaviour
{
    public DoorTransition door1;
    public DoorTransition door2;

    public int sceneIndex;
    [HideInInspector]
    public bool levelFinished = false;

    [Header("Audio")]
    public AudioSource leavingLevelSFX;

    void Update()
    {
        if (door1.pcReady && door2.pcReady && !levelFinished) // if both PCs are ready
        {
            levelFinished = true;
            AudioSource sfx = Instantiate(leavingLevelSFX, GameManager.gm.transform);
            Destroy(sfx.gameObject, 10);
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
