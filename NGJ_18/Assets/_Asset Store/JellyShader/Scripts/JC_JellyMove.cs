using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JC_JellyMove : MonoBehaviour
{
    RaycastHit hit;
    Ray clickRay;

    Renderer modelRenderer;
    float controlTime;

    private JC_Move movement;

    // Use this for initialization
    void Start()
    {
        modelRenderer = GetComponent<MeshRenderer>();
        movement = gameObject.GetComponent<JC_Move>();

        if (movement == null)
        {
            print("No movement script found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        controlTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(clickRay, out hit))
            {
                controlTime = 0;

                modelRenderer.material.SetVector("_ModelOrigin", transform.position);
                //modelRenderer.material.SetVector("_ImpactOrigin", hit.point);
                modelRenderer.material.SetVector("_ImpactOrigin", new Vector3(0, 1, -10));

                print(hit.point);
            }
        }

        //if (movement.isMoving)
        //{
        //    controlTime = 0;

        //    modelRenderer.material.SetVector("_ModelOrigin", transform.position);
        //    //modelRenderer.material.SetVector("_ImpactOrigin", hit.point);
        //    modelRenderer.material.SetVector("_ImpactOrigin", movement.agent.steeringTarget * 10);

        //    print(movement.agent.steeringTarget * 10);
        //}

        modelRenderer.material.SetFloat("_ControlTime", controlTime);
    }
}
