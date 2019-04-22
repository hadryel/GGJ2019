using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private MeshRenderer renderer = null;

    public Vector2 speed = new Vector2(0.01f, 0);

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();    
    }

    void Update()
    {
        if (!this.renderer)
        {
            return;
        }
        this.renderer.material.mainTextureOffset += Time.deltaTime * this.speed;
    }
}
