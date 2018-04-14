using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JC_Move : MonoBehaviour
{
    [SerializeField] private bool isRigidbody;
    [SerializeField] private bool isCharacterController;
    [SerializeField] private bool isNavMesh = true;

    private Rigidbody rb;
    private CharacterController cc;
    private NavMeshAgent agent;

    [SerializeField] private float speed;
    [SerializeField] private float drag;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        GetInputRB();
    }

    private void GetInput()
    {
        if (isCharacterController)
        {
            isRigidbody = false;
            isNavMesh = false;

            rb.isKinematic = true;

            float mH = Input.GetAxis("Horizontal");
            float mV = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(mH, 0, mV);

            cc.Move(movement * speed / 3);
        }

        if (isNavMesh)
        {
            isRigidbody = false;
            isCharacterController = false;

            cc.enabled = false;

            float mH = Input.GetAxis("Horizontal");
            float mV = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(mH, 0, mV);

            agent.Move(movement * speed / 5);
            rb.drag = drag;
        }
    }

    private void GetInputRB()
    {
        if (isRigidbody)
        {
            isNavMesh = false;
            isCharacterController = false;

            cc.enabled = false;

            if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0)
            {
                float mH = Input.GetAxis("Horizontal");
                float mV = Input.GetAxis("Vertical");

                rb.velocity = new Vector3(mH * speed * 5, rb.velocity.y, mV * speed * 5);
            }

            else if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
    }
}