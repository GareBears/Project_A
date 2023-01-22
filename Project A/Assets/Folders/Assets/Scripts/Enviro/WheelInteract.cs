using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelInteract : Interactable
{
    public GameObject highlight;
    public Material highColor;

    public override void OnFocus()
    {
        highlight.GetComponent<MeshRenderer>().material = highColor;
    }

    public override void OnInteract()
    {
        print("Interacted with gameObject.name");
    }

    public override void OnLoseFocus()
    {
        print("Stopped looking at gameObject.name");
    }
}
