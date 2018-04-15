using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransition : MonoBehaviour
{
    public DoorTransitionHub hub;

    [SerializeField]
    int playerNumber;

    [HideInInspector]
    public bool pcReady;

    bool pcInside;

    public TextMesh message;

    void Update()
    {
        if (GameManager.gm.PlayerOne && GameManager.gm.PlayerTwo && InRangeOfDoor())
        {
            ShowMessage();

            if (!pcReady)
            {
                if (playerNumber == 1)
                {
                    if (Input.GetButtonDown("A1"))
                    {
                        pcReady = true;
                    }
                }
                else
                {
                    if (Input.GetButtonDown("A2"))
                    {
                        pcReady = true;
                    }
                }
            }
        }
    }

    bool InRangeOfDoor()
    {
        if (playerNumber == 1)
        {
            if ((GameManager.gm.PlayerOne.transform.position - transform.position).sqrMagnitude <= 4)
            {
                return pcInside = true;
            }
            else
            {
                return pcInside = pcReady = false;
            }
        }
        else if (playerNumber == 2)
        {
            if ((GameManager.gm.PlayerTwo.transform.position - transform.position).sqrMagnitude <= 4)
            {
                return pcInside = true;
            }
            else
            {
                return pcInside = pcReady = false;
            }
        }
        else
        {
            Debug.LogError("Something about player number");
            return false;
        }
    }

    void ShowMessage()
    {
        message.gameObject.SetActive(true);
        if (hub.IsOtherReady(this))         // if the other PC is ready to go
        {
            if (pcReady)                   // if only the other PC is ready
            {
                message.text = "Press A to leave";
            }
            else                            // if both PCs are ready
            {
                message.text = "LET'S GO!";
            }
        }
        else                                // if the other PC is not yet ready
        {
            if (pcReady)                    // if this PC is ready
            {
                message.text = "Waiting for your blubber half";
            }
            else                            // if both PCs are not ready
            {
                message.text = "Press A to leave";
            }
        }
    }

    void HideMessage()
    {
        message.gameObject.SetActive(false);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.layer == 9)
    //    {
    //        pcInside = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.layer == 9)
    //    {
    //        pcInside = pcReady = false;
    //        HideMessage();
    //    }
    //}
}
