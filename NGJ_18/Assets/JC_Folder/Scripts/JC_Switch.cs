using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JC_Switch : MonoBehaviour
{
    private Animator animator;
    public bool isOn = false;
    public GameObject objToDeactivate;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
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
            }
        }
    }
}
