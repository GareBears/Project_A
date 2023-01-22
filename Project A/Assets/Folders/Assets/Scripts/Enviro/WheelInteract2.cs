using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelInteract2 : Interactable
{
    //public GameObject highlight;
    public Material highColor;
    public Material regColor;

    private bool doorOpen = false;

    [SerializeField] private Animator doorAnim = null;
    [SerializeField] private string WheelopenAnimation = "Wheel_Open2";
    //[SerializeField] private string closeAnimationName = "Wheel_Close2";
    [SerializeField] private string DoorcloseAnimation = "Door_Close";

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    public GameObject door;
    public GameObject wheel;
    DoorAnima a;
    WheelInteract p;

    public override void OnFocus()
    {
        GetComponent<MeshRenderer>().material = highColor;
    }

    public override void OnInteract()
    {
        if (!doorOpen && !pauseInteraction)
        {
            doorAnim.Play(WheelopenAnimation, 0, 0.0f);
            doorOpen = true;
            StartCoroutine(PauseDoorInteraction());
            //a.MethodA(gameObject);
            p.MethodWOP(gameObject);
        }

        else if (doorOpen && !pauseInteraction)
        {
            doorAnim.Play(DoorcloseAnimation, 0, 0.0f);
            //doorAnim.Play(closeAnimationName, 0, 0.0f);
            doorOpen = false;
            StartCoroutine(PauseDoorInteraction());
            //a.MethodB(gameObject);
            p.MethodWCP(gameObject);
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
        p = GameObject.FindGameObjectWithTag("TagWheel").GetComponent<WheelInteract>();
        MethodWO(gameObject);
        MethodWC(gameObject);
    }

    public void MethodWO(GameObject g)
    {
        doorOpen = true;
    }

    public void MethodWC(GameObject g)
    {
        doorOpen = false;
    }
}
