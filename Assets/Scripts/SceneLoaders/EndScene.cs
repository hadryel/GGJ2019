using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : SceneLoader
{
    public override void LoadScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}
