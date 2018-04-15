using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JC_Move : MonoBehaviour
{
    public int playerNumber;
    [HideInInspector] public Rigidbody rb1;
    [HideInInspector] public Rigidbody rb2;

    [HideInInspector]
    public NavMeshAgent agent1;
    [HideInInspector]
    public NavMeshAgent agent2;

    public float speed;
    public float drag;

    [HideInInspector] public bool isMovingOne;
    [HideInInspector] public bool isMovingTwo;

    //"Controller (XBOX 360 For Windows)"

    // Use this for initialization
    private void Start()
    {
        if (GameManager.gm.PlayerOne)
        {
            rb1 = GameManager.gm.PlayerOne.GetComponent<Rigidbody>();
            agent1 = GameManager.gm.PlayerOne.GetComponent<NavMeshAgent>();
        }

        if (GameManager.gm.PlayerTwo)
        {
            rb2 = GameManager.gm.PlayerTwo.GetComponent<Rigidbody>();
            agent2 = GameManager.gm.PlayerTwo.GetComponent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    public void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (GameManager.gm.PlayerOne)
        {
            if (Input.GetAxis("Horizontal1") > 0 || Input.GetAxis("Vertical1") > 0 || Input.GetAxis("Horizontal1") < 0 || Input.GetAxis("Vertical1") < 0)
            {
                isMovingOne = true;

                float mH1 = Input.GetAxis("Horizontal1");
                float mV1 = Input.GetAxis("Vertical1");

                Vector3 movement = new Vector3(mH1, 0, mV1);

                agent1.Move(movement * speed / 5);
            }

            else if (Input.GetAxis("Horizontal1") == 0 && Input.GetAxis("Vertical1") == 0)
            {
                isMovingOne = false;
            } 
        }

        if (GameManager.gm.PlayerTwo)
        {
            if (Input.GetAxis("Horizontal2") > 0 || Input.GetAxis("Vertical2") > 0 || Input.GetAxis("Horizontal2") < 0 || Input.GetAxis("Vertical2") < 0)
            {
                isMovingTwo = true;

                float mH2 = Input.GetAxis("Horizontal2");
                float mV2 = Input.GetAxis("Vertical2");

                Vector3 movement = new Vector3(mH2, 0, mV2);

                agent2.Move(movement * speed / 5);
            }

            else if (Input.GetAxis("Horizontal2") == 0 && Input.GetAxis("Vertical2") == 0)
            {
                isMovingTwo = false;
            }
        }
    }
}