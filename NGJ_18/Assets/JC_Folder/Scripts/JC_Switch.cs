using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JC_Switch : MonoBehaviour
{
<<<<<<< Updated upstream
    public bool isOn = false;

    public int player;

    public JB_DoorOpening doorOpening;
    private bool pc1IsInside;
    private bool pc2IsInside;
=======
    private Animator animator;
    public bool isOn = false;
    public GameObject objToDeactivate;
>>>>>>> Stashed changes

    // Use this for initialization
    void Start()
    {

    }

<<<<<<< Updated upstream
    private void Update()
    {
        if (pc1IsInside || pc2IsInside)
        {
            if (Input.GetButtonDown((player == 1 ? "A1" : "A2")))
            {
                print("Opened Door");
                isOn = !isOn;
                doorOpening.DoorInteract();
            }
        }
=======
    // Update is called once per frame
    void Update()
    {

>>>>>>> Stashed changes
    }

    private void OnTriggerEnter(Collider other)
    {
<<<<<<< Updated upstream
        if (other.gameObject.layer == 9)
        {
            print("We're in");

            if (player == 1 && other.gameObject == GameManager.gm.PlayerOne.gameObject)
            {
                print("We're in 1");
                // Player1 Interacted with Trigger
                pc1IsInside = true;             
            }

            else if (player == 2 && other.gameObject == GameManager.gm.PlayerTwo.gameObject)
            {
                print("We're in 2");
                pc2IsInside = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            print("We're out");

            if (player == 1 && other.gameObject == GameManager.gm.PlayerOne.gameObject)
            {
                print("We're out 1");
                // Player1 Interacted with Trigger
                pc1IsInside = false;
            }

            else if (player == 2 && other.gameObject == GameManager.gm.PlayerTwo.gameObject)
            {
                print("We're out 2");
                pc2IsInside = false;
=======
        if (Input.GetButtonDown("A1"))
        {
            // Player1 Interacted with Trigger
            if (other.GetComponent<JC_Move>() != null)
            {
                if (!isOn)
                {
                    isOn = true;

                    animator.SetBool("isOpen", true);
                }

                else if (isOn)
                {
                    isOn = true;

                    animator.SetBool("isOpen", false);
                }
>>>>>>> Stashed changes
            }
        }
    }
}
