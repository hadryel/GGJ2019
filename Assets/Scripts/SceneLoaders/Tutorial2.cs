using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial2 : SceneLoader
{
    public override void LoadScene()
    {
        SceneManager.LoadScene("Tutorial2");
    }
}
