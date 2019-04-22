using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchActivator : MonoBehaviour
{
    public Sprite ActiveStateSprite;

    public UnityEvent ActivationEvent;

    void Update() { }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<OwnerController>() &&
        col.gameObject.GetComponent<OwnerController>().enabled)
        {
            col.gameObject.GetComponentInParent<InputHandler>().ActionInput += Activate;
            col.gameObject.GetComponentInParent<InputHandler>().ActionInput += col.gameObject.GetComponent<OwnerController>().ActivateMechanic;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<OwnerController>())
        {
            col.gameObject.GetComponentInParent<InputHandler>().ActionInput -= Activate;
            col.gameObject.GetComponentInParent<InputHandler>().ActionInput -= col.gameObject.GetComponent<OwnerController>().ActivateMechanic;
        }
    }

    public void Activate()
    {
        ActivationEvent?.Invoke();
        GetComponent<SpriteRenderer>().sprite = ActiveStateSprite;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
