using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JC_Move : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb1;
    [HideInInspector] public Rigidbody rb2;

    [HideInInspector]
    public NavMeshAgent agent1;
    [HideInInspector]
    public NavMeshAgent agent2;

    [SerializeField] private float speed;
    [SerializeField] private float drag;

    private GameManager manager;

    [HideInInspector] public bool isMovingOne;
    [HideInInspector] public bool isMovingTwo;

    //"Controller (XBOX 360 For Windows)"

    // Use this for initialization
    private void Start()
    {
        manager = FindObjectOfType<GameManager>();

        rb1 = manager.PlayerOne.GetComponent<Rigidbody>();
        rb2 = manager.PlayerTwo.GetComponent<Rigidbody>();

        agent1 = manager.PlayerOne.GetComponent<NavMeshAgent>();
        agent2 = manager.PlayerTwo.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (manager.PlayerOne)
        {
            if (Input.GetAxis("Horizontal1") > 0 || Input.GetAxis("Vertical1") > 0 || Input.GetAxis("Horizontal1") < 0 || Input.GetAxis("Vertical1") < 0)
            {
                isMovingOne = true;

                float mH1 = Input.GetAxis("Horizontal1");
                float mV1 = Input.GetAxis("Vertical1");

                Vector3 movement = new Vector3(mH1, 0, mV1);

                agent1.Move(movement * speed / 5);
                //rb1.drag = drag;

                print(new Vector3(mH1, 0, mV1));
            }

            else if (Input.GetAxis("Horizontal1") == 0 && Input.GetAxis("Vertical1") == 0)
            {
                isMovingOne = false;
            } 
        }

        if (manager.PlayerTwo)
        {
            if (Input.GetAxis("Horizontal2") > 0 || Input.GetAxis("Vertical2") > 0 || Input.GetAxis("Horizontal2") < 0 || Input.GetAxis("Vertical2") < 0)
            {
                isMovingTwo = true;

                float mH2 = Input.GetAxis("Horizontal2");
                float mV2 = Input.GetAxis("Vertical2");

                Vector3 movement = new Vector3(mH2, 0, mV2);

                agent2.Move(movement * speed / 5);
                //rb2.drag = drag;

                print(new Vector3(mH2, 0, mV2));
            }

            else if (Input.GetAxis("Horizontal2") == 0 && Input.GetAxis("Vertical2") == 0)
            {
                isMovingTwo = false;
            }
        }
    }
}