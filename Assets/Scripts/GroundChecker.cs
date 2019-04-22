using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D col)
    {
        GetComponentInParent<PlayerController>().IsGrounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        GetComponentInParent<PlayerController>().IsGrounded = false;
    }
}
