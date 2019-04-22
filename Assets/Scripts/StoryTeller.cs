using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryTeller : MonoBehaviour
{
    public UnityEvent FinishStory;

    public Image[] Frames;
    public float[] Durations;
    public float FadeDuration = 1f;
    public int FrameIndex;

    Canvas Canvas;
    Image CurrentFrame;

    public bool EndScene;

    void Start()
    {
        CurrentFrame = GetComponentInChildren<Image>();

        StartCoroutine(DisplayFrame(Frames[FrameIndex]));
    }

    IEnumerator DisplayFrame(Image frame)
    {
        var duration = Time.time;

        CurrentFrame.sprite = frame.sprite;

        for (float alpha = 0f; alpha <= 1; alpha += Time.deltaTime)
        {
            CurrentFrame.color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }

        CurrentFrame.color = new Color(1f, 1f, 1f, 1f);

        yield return new WaitForSeconds(Durations[FrameIndex]);

        StartCoroutine(HideCurrentFrame());
    }

    IEnumerator HideCurrentFrame()
    {
        var duration = Time.time;

        for (float alpha = 1f; alpha >= 0; alpha -= Time.deltaTime)
        {
            CurrentFrame.color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }

        CurrentFrame.color = new Color(1f, 1f, 1f, 0f);

        FrameIndex++;

        if (FrameIndex < Frames.Length)
        {
            StartCoroutine(DisplayFrame(Frames[FrameIndex]));
        }
        else
        {
            FinishStory?.Invoke();
        }
    }

    public void StartGame()
    {
        if (EndScene)
            SceneManager.LoadScene("PoemScene");
        else
            SceneManager.LoadScene("Tutorial1");
    }
}
