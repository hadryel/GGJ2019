using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBlock : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<OwnerController>() &&
        col.gameObject.GetComponent<OwnerController>().enabled)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<OwnerController>())
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            col.gameObject.GetComponentInChildren<Animator>().SetBool("push", false);

        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<OwnerController>() &&
        col.gameObject.GetComponent<OwnerController>().enabled)
        {
            col.gameObject.GetComponentInChildren<Animator>().SetBool("push", GetComponent<Rigidbody2D>().velocity.x != 0);
        }
    }
}
