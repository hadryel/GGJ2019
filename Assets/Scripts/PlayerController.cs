using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public InputHandler InputHandler;
    protected Rigidbody2D RigidBody;

    float MovementSpeed = 2.5f;
    float JumpSpeed = 7f;

    bool IsFalling;
    bool IsJumping;
    public bool IsGrounded;


    public static DogController Dog;
    public static OwnerController Owner;

    protected static float FallSpeedMultiplier = 1.5f;

    int CollisionCount;

    public void MoveInDirection(Vector2 direction)
    {
        if (direction.x != 0)
        {
            var angle = (direction.x > 0) ? 0 : 180;
            transform.GetChild(0).localRotation = Quaternion.AngleAxis(angle, Vector3.up);
        }

        GetComponentInChildren<Animator>().SetBool("move", direction.magnitude > 0);

        direction.x = direction.x * MovementSpeed;
        direction.y = RigidBody.velocity.y;

        RigidBody.velocity = direction;
    }

    public void Jump()
    {
        if (IsJumping || IsFalling)
            return;

        IsJumping = true;

        GetComponentInChildren<Animator>().SetBool("jump", true);

        Vector2 velocity = RigidBody.velocity;
        velocity.y = JumpSpeed;
        RigidBody.velocity = velocity;

        StartCoroutine("WaitFall");
    }

    IEnumerator WaitFall()
    {
        yield return new WaitUntil(() => { return RigidBody.velocity.y <= 0.05f; });

        IsJumping = false;
        IsFalling = true;

        GetComponentInChildren<Animator>().SetBool("fall", true);
    }

    public bool CheckIfGrounded()
    {
        return IsGrounded;
        // var hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        // return hit;
    }

    public void ToggleOrder()
    {
        if (Dog == null || Owner == null)
            return;

        Dog.enabled = !Dog.enabled;
        Owner.enabled = !Owner.enabled;

        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    //Remove this function from the player one day - put somewhere else
    public void ResetStage()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (CheckIfGrounded() && !IsJumping)
        {
            if (IsFalling)
            {
                IsFalling = false;

                GetComponentInChildren<Animator>().SetBool("land", true);
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (!CheckIfGrounded())
        {
            if (!IsJumping && !IsFalling)
            {
                IsFalling = true;

                GetComponentInChildren<Animator>().SetBool("fall", true);
            }
        }
    }

    public PlayerController GetOtherController()
    {
        return (this == Dog) ? (PlayerController)Owner : (PlayerController)Dog;
    }
}
