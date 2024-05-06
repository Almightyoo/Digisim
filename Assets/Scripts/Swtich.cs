using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public GameObject Switch;
    public Color onColor;
    public Color offColor;
    public bool On = false;
    
    public void OnMouseDown()
    {
        if (On==false)
        {
            Switch.GetComponent<SpriteRenderer>().color = onColor;
            On = true;
        }
        else
        {
            Switch.GetComponent<SpriteRenderer>().color = offColor;
            On = false;
        }
        
    }
   
}
