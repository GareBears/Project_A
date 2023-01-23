using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteract : Interactable
{
    //public GameObject highlight;
    public Material highColor;
    public Material regColor;

    [SerializeField] private Animator leverAnim = null;
    private bool doorOpen = false;

    [SerializeField] private string openAnimationName = "Lever";
    [SerializeField] private string closeAnimationName = "Lever2";

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    public GameObject door;
    BigDoorLeft a;

    public override void OnFocus()
    {
        GetComponent<MeshRenderer>().material = highColor;
    }

    public override void OnLoseFocus()
    {
        GetComponent<MeshRenderer>().material = regColor;
    }

    public override void OnInteract()
    {
        if (!doorOpen && !pauseInteraction)
        {
            leverAnim.Play(openAnimationName, 0, 0.0f);
            doorOpen = true;
            StartCoroutine(PauseDoorInteraction());
            a.MethodA(gameObject);
        }

        else if (doorOpen && !pauseInteraction)
        {
            leverAnim.Play(closeAnimationName, 0, 0.0f);
            doorOpen = false;
            StartCoroutine(PauseDoorInteraction());
            a.MethodB(gameObject);
        }
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    public void Start()
    {
        a = GameObject.FindGameObjectWithTag("TagDoor").GetComponent<BigDoorLeft>();
    }



}
