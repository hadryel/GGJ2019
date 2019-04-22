using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerController : PlayerController
{
    void Awake()
    {
        PlayerController.Owner = this;

        RigidBody = GetComponent<Rigidbody2D>();
        InputHandler = GetComponentInParent<InputHandler>();
    }

    void OnEnable()
    {
        RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

        GetComponentInChildren<SpriteRenderer>().sortingOrder++;

        InputHandler.DirectionInput += MoveInDirection;
        InputHandler.JumpInput += Jump;
        InputHandler.ChangeOrderInput += ToggleOrder;
        InputHandler.ResetStageInput += ResetStage;
    }

    void OnDisable()
    {
        RigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        GetComponentInChildren<SpriteRenderer>().sortingOrder--;

        InputHandler.DirectionInput -= MoveInDirection;
        InputHandler.JumpInput -= Jump;
        InputHandler.ChangeOrderInput -= ToggleOrder;
        InputHandler.ResetStageInput -= ResetStage;

        var velocity = RigidBody.velocity;
        velocity.x = 0;
        RigidBody.velocity = velocity;

        GetComponentInChildren<Animator>().SetBool("move", false);
    }

    public void ActivateMechanic()
    {
        GetComponentInChildren<Animator>().SetBool("act", true);

        StartCoroutine("ActivationDelay");

        enabled = false;
    }

    IEnumerator ActivationDelay()
    {
        yield return new WaitForSeconds(0.8f);

        enabled = true;
    }

    void Update()
    {
        if (RigidBody.velocity.y < 0)
            RigidBody.velocity += Vector2.up * Physics2D.gravity.y * (FallSpeedMultiplier - 1) * Time.deltaTime;
    }
}
