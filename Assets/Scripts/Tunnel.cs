using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{
    public float FadeSpeed = 1f;

    public Tunnel Connection;
    public Vector3 EntrancePosition;

    DogController Dog;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<DogController>() &&
        col.gameObject.GetComponent<DogController>().enabled)
        {
            col.gameObject.GetComponentInParent<InputHandler>().ActionInput += Traverse;
            Dog = col.gameObject.GetComponent<DogController>();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<DogController>())
        {
            col.gameObject.GetComponentInParent<InputHandler>().ActionInput -= Traverse;
        }
    }

    public void Traverse()
    {
        StartCoroutine("TraverseRoutine");
    }

    IEnumerator TraverseRoutine()
    {
        yield return null;
        
        Dog.enabled = false;

        for (float alpha = 1f; alpha >= 0; alpha -= Time.deltaTime * FadeSpeed)
        {
            Dog.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }

        Dog.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);

        Dog.transform.position = Connection.EntrancePosition;

        for (float alpha = 0f; alpha <= 1; alpha += Time.deltaTime * FadeSpeed)
        {
            Dog.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }

        Dog.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

        Dog.enabled = true;
    }
}
