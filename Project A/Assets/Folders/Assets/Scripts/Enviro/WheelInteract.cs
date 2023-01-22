using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelInteract : Interactable
{
    //public GameObject highlight;
    public Material highColor;
    public Material regColor;

    private bool doorOpen = false;

    [SerializeField] private Animator doorAnim = null;
    [SerializeField] private string openAnimationName = "Wheel_Open";
    //[SerializeField] private string closeAnimationName = "Wheel_Close";
    [SerializeField] private string closeAnimationName2 = "Door_Close";

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    public GameObject door;
    public GameObject wheel2;
    DoorAnima a;
    WheelInteract2 w;

    public override void OnFocus()
    {
        GetComponent<MeshRenderer>().material = highColor;
    }

    public override void OnInteract()
    {
        if (!doorOpen && !pauseInteraction)
        {
            doorAnim.Play(openAnimationName, 0, 0.0f);
            doorOpen = true;
            StartCoroutine(PauseDoorInteraction());
            //a.MethodA(gameObject);
            w.MethodWO(gameObject);
        }

        else if (doorOpen && !pauseInteraction)
        {
            doorAnim.Play(closeAnimationName2, 0, 0.0f);
            //doorAnim.Play(closeAnimationName, 0, 0.0f);
            doorOpen = false;
            StartCoroutine(PauseDoorInteraction());
            //a.MethodB(gameObject);
            w.MethodWC(gameObject);
        }
    }

    public override void OnLoseFocus()
    {
        GetComponent<MeshRenderer>().material = regColor;
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    public void Start()
    {
        a = GameObject.FindGameObjectWithTag("TagDoor").GetComponent<DoorAnima>();
        w = GameObject.FindGameObjectWithTag("TagWheel2").GetComponent<WheelInteract2>();
        MethodWOP(gameObject);
        MethodWCP(gameObject);
    }

    public void MethodWOP(GameObject g)
    {
        doorOpen = true;
    }

    public void MethodWCP(GameObject g)
    {
        doorOpen = false;
    }
}
