using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : SceneLoader
{
    public override void LoadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
