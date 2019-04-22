using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggableBlock : MonoBehaviour
{
    public GameObject DirtyParticles;

    public void Dig()
    {
        Instantiate(DirtyParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
