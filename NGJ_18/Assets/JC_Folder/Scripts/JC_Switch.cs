using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JC_Switch : MonoBehaviour
{
    public bool isOn = false;

    public int player;

    public float breakerDelay = 1;

    public JB_DoorOpening doorOpening;
    private bool pc1IsInside;
    private bool pc2IsInside;

    private JC_SwitchManager switchManager;

    // Use this for initialization
    void Start()
    {
        switchManager = FindObjectOfType<JC_SwitchManager>();
    }

    private void Update()
    {
        if (pc1IsInside || pc2IsInside)
        {
            if (Input.GetButtonDown((player == 1 ? "A1" : "A2")))
            {
                print("Opened Door");
                isOn = !isOn;
                DoorInteract();
                switchManager.AddOnSwitch();
            }
        }

        if (Vector3.Distance(GameManager.gm.PlayerOne.gameObject.transform.position, gameObject.transform.position) <= 2)
        {
            print("We're in 1");
            // Player1 Interacted with Trigger
            pc1IsInside = true;
        }

        else
        {
            pc1IsInside = false;
        }


        if (Vector3.Distance(GameManager.gm.PlayerTwo.gameObject.transform.position, gameObject.transform.position) <= 2)
        {
            print("We're in 2");
            // Player1 Interacted with Trigger
            pc2IsInside = true;
        }
        else
        {
            pc2IsInside = false;
        }

    }
    void DoorInteract()
    {
        doorOpening.DoorInteract();
    }
    public void HasBroken()
    {
        Invoke("DoorInteract", breakerDelay);
    }
}
