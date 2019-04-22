using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageGoal : MonoBehaviour
{
    int ClearCount = 2;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ClearCount--;

            if (ClearCount == 0)
                GetComponent<SceneLoader>().LoadScene();

            col.GetComponent<PlayerController>().ToggleOrder();

            Destroy(col.gameObject);
        }
    }
}
