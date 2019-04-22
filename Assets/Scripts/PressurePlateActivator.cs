using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlateActivator : MonoBehaviour
{
    public UnityEvent ActivationEvent;
    public UnityEvent DeactivationEvent;

    public Sprite ActiveStateSprite;
    Sprite DefaultSprite;

    void Start()
    {
        DefaultSprite = GetComponent<SpriteRenderer>().sprite;
    }

    void Update() { }

    int ActivationCount;

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.GetComponent<OwnerController>() &&
        col.gameObject.GetComponent<OwnerController>().enabled) || (col.gameObject.GetComponent<DogController>() &&
        col.gameObject.GetComponent<DogController>().enabled) || col.gameObject.GetComponent<PushableBlock>())
        {
            ActivationCount++;
            Activate();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if ((col.gameObject.GetComponent<OwnerController>() &&
        col.gameObject.GetComponent<OwnerController>().enabled) || (col.gameObject.GetComponent<DogController>() &&
        col.gameObject.GetComponent<DogController>().enabled) || col.gameObject.GetComponent<PushableBlock>())
        {
            ActivationCount--;

            if (ActivationCount == 0)
                Deactivate();
        }
    }

    public void Activate()
    {
        ActivationEvent?.Invoke();
        GetComponent<SpriteRenderer>().sprite = ActiveStateSprite;
    }

    public void Deactivate()
    {
        DeactivationEvent?.Invoke();
        GetComponent<SpriteRenderer>().sprite = DefaultSprite;
    }
}
