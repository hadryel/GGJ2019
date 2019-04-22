using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationTests : MonoBehaviour
{
    private Animator animator = null;
    private RaycastHit2D[] hits = new RaycastHit2D[1];

    void Start()
    {
        this.animator = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal"))
        {
            var move = Input.GetAxis("Horizontal");
            this.transform.position = this.transform.position + new Vector3(move * 0.1f, 0, 0);
            this.transform.rotation = Quaternion.Euler(new Vector3(0, move < 0 ? 180 : 0, 0));
            this.animator.SetBool("move", true);

            var raycast = Physics2D.Raycast(this.transform.position, move < 0 ? Vector2.left : Vector2.right, 1.1f, ~LayerMask.GetMask("Player"));
            if (raycast.collider)
            {
                Debug.Log(raycast.collider);
                this.animator.SetBool("push", true);
            }
            else
            {
                this.animator.SetBool("push", false);
            }
        }
        else
        {
            this.animator.SetBool("move", false);
            this.animator.SetBool("push", false);
        }
    }
}
