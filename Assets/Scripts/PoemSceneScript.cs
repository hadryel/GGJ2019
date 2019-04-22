using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoemSceneScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("WaitForCredits");
    }

    IEnumerator WaitForCredits()
    {
        yield return new WaitForSeconds(10f);

        SceneManager.LoadScene("Credits");
    }
}
