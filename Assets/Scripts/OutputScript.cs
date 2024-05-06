using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputScript : MonoBehaviour
{
    public bool outputOn;
    public GameObject Circle;
    public Color onColor;
    public Color offColor;
   
    public void Update()
    {
        if (outputOn == true)
        {
            Circle.GetComponent<SpriteRenderer>().color = onColor;
        }
        else
        {
            Circle.GetComponent<SpriteRenderer>().color = offColor;
        }
    }
}
