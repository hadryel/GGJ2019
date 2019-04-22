using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivableSwitch : MonoBehaviour
{
    public UnityEvent Activate;

    void Update() { }

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<OwnerController>())
        {
            col.gameObject.GetComponent<OwnerController>().InputHandler.ActionInput += Activate.Invoke;
        }
    }

    void OnTriggeExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<OwnerController>())
        {
            col.gameObject.GetComponent<OwnerController>().InputHandler.ActionInput -= Activate.Invoke;
        }
    }

    public void Test(){
        Debug.Log("TEseeete");
    }

}
