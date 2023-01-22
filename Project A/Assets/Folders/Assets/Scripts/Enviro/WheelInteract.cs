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
    [SerializeField] private string closeAnimationName = "Wheel_Close";

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    public GameObject door;
    DoorAnima a;

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
        }

        else if (doorOpen && !pauseInteraction)
        {
            doorAnim.Play(closeAnimationName, 0, 0.0f);
            doorOpen = false;
            StartCoroutine(PauseDoorInteraction());
            //a.MethodB(gameObject);
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
    }
}
