using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : PlayerController
{
    public GameObject DirtyParticles;

    Vector2 DigDirection;

    void Awake()
    {
        PlayerController.Dog = this;

        RigidBody = GetComponent<Rigidbody2D>();
        InputHandler = GetComponentInParent<InputHandler>();
    }

    void OnEnable()
    {
        RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

        GetComponentInChildren<SpriteRenderer>().sortingOrder++;

        InputHandler.ActionInput += DigBlock;
        InputHandler.DirectionInput += MoveInDirection;
        InputHandler.DirectionInput += UpdateDigDirection;
        InputHandler.JumpInput += Jump;
        InputHandler.ChangeOrderInput += ToggleOrder;
        InputHandler.ResetStageInput += ResetStage;
    }

    void OnDisable()
    {
        RigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        GetComponentInChildren<SpriteRenderer>().sortingOrder--;

        InputHandler.ActionInput -= DigBlock;
        InputHandler.DirectionInput -= MoveInDirection;
        InputHandler.DirectionInput -= UpdateDigDirection;
        InputHandler.JumpInput -= Jump;
        InputHandler.ChangeOrderInput -= ToggleOrder;
        InputHandler.ResetStageInput -= ResetStage;

        var velocity = RigidBody.velocity;
        velocity.x = 0;
        RigidBody.velocity = velocity;

        GetComponentInChildren<Animator>().SetBool("move", false);
    }

    void Update()
    {
        if (RigidBody.velocity.y < 0)
            RigidBody.velocity += Vector2.up * Physics2D.gravity.y * (FallSpeedMultiplier - 1) * Time.deltaTime;
    }

    public void DigBlock()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, DigDirection, 0.5f);

        if (hit && hit.collider.CompareTag("DiggableBlock"))
        {
            var block = hit.collider.gameObject;

            GetComponentInChildren<Animator>().SetBool("dig", true);

            enabled = false;

            StartCoroutine("DigDelay", block);
        }
    }

    IEnumerator DigDelay(GameObject block)
    {
        Instantiate(DirtyParticles, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.5f);

        Destroy(block);

        enabled = true;
    }

    public void UpdateDigDirection(Vector2 direction)
    {
        if (direction.x > 0)
            DigDirection = Vector2.right;
        else if (direction.x < 0)
            DigDirection = Vector2.left;
        else if (direction.y > 0)
            DigDirection = Vector2.up;
        else
            DigDirection = Vector2.down;
    }
}
