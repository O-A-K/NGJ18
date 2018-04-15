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
        StartCoroutine(LightFlash());
        foreach (var Switch in allSwitches)
        {
            if (Switch.isOn)
            {
                Switch.HasBroken();
            }
        }
    }

    IEnumerator LightFlash()
    {
        float progress = 0;
        float timer = 0;
        float lightLerp = 1.5f;
        float lightIntensity = GameManager.gm.mainLight.intensity;
        GameManager.gm.mainLight.intensity = 0;

        while (progress < 1)
        {
            timer += Time.deltaTime;
            progress = timer / lightLerp;

            GameManager.gm.mainLight.intensity = Mathf.Lerp(0, lightIntensity, progress);

            yield return null;
        }
    }
}
