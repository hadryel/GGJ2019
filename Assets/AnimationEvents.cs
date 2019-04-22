using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AnimationEvents : MonoBehaviour
{
    private AudioSource source = null;

    public AudioClip walk = null;
    public AudioClip jump = null;
    public AudioClip fall = null;
    public AudioClip land = null;
    public AudioClip action = null;

    private void Start()
    {
        this.source = GetComponent<AudioSource>();
    }

    private void Play(AudioClip clip)
    {
        if (this.source != null)
        {
            this.source.PlayOneShot(clip);
        }
    }

    public void OnWalk()
    {
        this.Play(this.walk);
    }

    public void OnJump()
    {
        this.Play(this.jump);
    }

    public void OnFall()
    {
        this.Play(this.fall);
    }

    public void OnLand()
    {
        this.Play(this.land);
    }

    public void OnAction()
    {
        this.Play(this.action);
    }
}
