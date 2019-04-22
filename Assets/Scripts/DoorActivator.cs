using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    public float ActivationSpeed = 1f;

    public void Activate()
    {
        StartCoroutine("ActivationRoutine");
    }

    public void Deactivate()
    {
        StopAllCoroutines();
        
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

        gameObject.SetActive(true);
    }

    IEnumerator ActivationRoutine()
    {
        for (float alpha = 1f; alpha >= 0; alpha -= Time.deltaTime)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);

        gameObject.SetActive(false);
    }
}
