using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class JB_SwitchManager : MonoBehaviour
{
    public static JB_SwitchManager sm;
    public int maxSwitches;
    public int switchCounter = 0;
    bool isBroken;

    public List<JB_Switch> allSwitches = new List<JB_Switch>();

    void Awake()
    {
        if (sm)
        {
            Destroy(this.gameObject);
        }
        else
        {
            sm = this;
        }
    }


    void Update()
    {
        if (switchCounter >= maxSwitches && !isBroken)
        {
            isBroken = true;
            Invoke("BREAKINGPOINT", .5f);
        }

        if (switchCounter == 0)
        {
            isBroken = false;
        }
    }

    public void SwitchOn()
    {
        switchCounter++;
    }

    public void SwitchOff()
    {
        switchCounter--;
    }

    void BREAKINGPOINT()
    {
        switchCounter = 0;

        foreach (var Switch in allSwitches)
        {
            if (Switch.isOn)
            {
                Switch.HasBroken();
            }
        }
    }
}
