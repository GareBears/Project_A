using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnima : MonoBehaviour
{
    private bool doorOpen = false;

    [SerializeField] private Animator doorAnim = null;
    [SerializeField] private string openAnimationName = "Door_Open";
    [SerializeField] private string closeAnimationName = "Door_Close";

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;


    // Start is called before the first frame update
    void Start()
    {
        MethodA(gameObject);
        MethodB(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MethodA(GameObject g)
    {
        //doorAnim.Play(openAnimationName, 0, 0.0f);
        //doorOpen = true;
        //StartCoroutine(PauseDoorInteraction());
    }

    public void MethodB(GameObject g)
    {
        //doorAnim.Play(closeAnimationName, 0, 0.0f);
        //doorOpen = false;
        //StartCoroutine(PauseDoorInteraction());
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }
}
