using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public delegate void DirectionEvent(Vector2 direction);
    public delegate void ActionEvent();

    public DirectionEvent DirectionInput;
    public ActionEvent ActionInput;
    public ActionEvent JumpInput;
    public ActionEvent ChangeOrderInput;
    public ActionEvent ResetStageInput;

    private void Update()
    {
        GetDirectionInput();
        GetJumpInput();
        GetChangeOrderInput();
        GetActionInput();
        GetResetStageInput();
    }

    void GetDirectionInput()
    {
        var direction = new Vector2();

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
        }

        DirectionInput?.Invoke(direction);
    }

    void GetJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            JumpInput?.Invoke();
        }
    }

    void GetChangeOrderInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeOrderInput?.Invoke();
        }
    }

    void GetActionInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActionInput?.Invoke();
        }
    }

    void GetResetStageInput(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetStageInput?.Invoke();
        }
    }
}
