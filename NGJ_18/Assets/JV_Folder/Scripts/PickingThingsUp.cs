using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingThingsUp : MonoBehaviour
{
    public Material outline;
    private Material temp;
    private Material[] No_Outline;
    private bool CarryingObject = false;
    private GameObject CarriedObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int layermask = 1 << 8;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layermask ))
        {
            if (hit.transform.gameObject.layer == 8 && hit.distance <= 5.0f)
            {
                No_Outline = hit.transform.gameObject.GetComponent<Renderer>().materials;
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green );
                for (int i = 0; i < hit.transform.gameObject.GetComponent<Renderer>().materials.Length; i++)
                {
                    hit.transform.gameObject.GetComponent<Renderer>().materials[i] = temp;
                    temp = outline;
                }
                if (Input.GetKeyDown(KeyCode.L) && !CarryingObject)
                {
                    Debug.Log("Picked up");
                    CarryingObject = true;
                    hit.transform.parent = this.transform;
                    CarriedObject = hit.transform.gameObject;
                }
                else if (Input.GetKeyDown(KeyCode.L) && CarryingObject)
                {
                    Debug.Log("Dropped Object");
                    CarryingObject = false;
                    CarriedObject.transform.parent = null;
                }
            }
            else
            {
                hit.transform.gameObject.GetComponent<Renderer>().materials = No_Outline;
            }
        }
    }
}
