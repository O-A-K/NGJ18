using UnityEngine;
using System.Collections;

public class JB_Switch : MonoBehaviour
{
    public int playerNumber = 0;

    public JB_DoorOpening door;

    public bool isOn;
    public bool doorStateOff;
    bool pcInside;
    bool isBroken;

    public float brokenTimeout = 2;
    float brokenTime;

    public ParticleSystem sparks;

    void Start()
    {
        if (playerNumber == 0)
        {
            Debug.LogError("Player number asshat");
        }

        if (isOn)
        {
            doorStateOff = !door.isOpen;
        }
        else
        {
            doorStateOff = door.isOpen;
        }

        JB_SwitchManager.sm.allSwitches.Add(this);
    }


    void Update()
    {
        if (!door.isMoving && GameManager.gm.PlayerOne && GameManager.gm.PlayerTwo && InRangeOfSwitch())
        {
            if (playerNumber == 1 && Input.GetButtonDown("A1"))
            {
                Switching();
            }
            else if (playerNumber == 2 && Input.GetButtonDown("A2"))
            {
                Switching();
            }

            if (sparks) sparks.gameObject.SetActive(false);
            if (door) door.electricShock.gameObject.SetActive(false);
        }
    }

    bool InRangeOfSwitch()
    {
        if (playerNumber == 1)
        {
            if ((GameManager.gm.PlayerOne.transform.position - transform.position).sqrMagnitude <= 2.25f)
            {
                return pcInside = true;
            }
            else
            {
                return pcInside = false;
            }
        }
        else if (playerNumber == 2)
        {
            if ((GameManager.gm.PlayerTwo.transform.position - transform.position).sqrMagnitude <= 2.25f)
            {
                return pcInside = true;
            }
            else
            {
                return pcInside = false;
            }
        }
        else
        {
            Debug.LogError("S0mething about playernumber");
            return false;
        }
    }

    void Switching()
    {
        print("PC has switched");
        if (isOn)
        {
            JB_SwitchManager.sm.SwitchOff();
        }
        else
        {
            JB_SwitchManager.sm.SwitchOn();
        }
        isOn = !isOn;
        door.DoorInteract();
    }

    public void HasBroken()
    {
        if (door.isOpen != doorStateOff)
        {
            door.DoorInteract();
        }
        if (sparks) sparks.gameObject.SetActive(true);
        if (door) door.electricShock.gameObject.SetActive(true);
        isOn = false;
        isBroken = true;
        brokenTime = Time.time + brokenTimeout;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.layer == 9)
    //    {
    //        print("PC inside");
    //        pcInside = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.layer == 9)
    //    {
    //        print("PC outside");
    //        pcInside = false;
    //    }
    //}
}
