using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelInteract : Interactable
{
    //public GameObject highlight;
    public Material highColor;
    public Material regColor;

    public override void OnFocus()
    {
        GetComponent<MeshRenderer>().material = highColor;
    }

    public override void OnInteract()
    {
        print("Interacted with gameObject.name");
    }

    public override void OnLoseFocus()
    {
        GetComponent<MeshRenderer>().material = regColor;
    }
}
