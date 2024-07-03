using UnityEngine;
using System.Collections.Generic;

public class GlobalColorManager : MonoBehaviour
{
    public static GlobalColorManager Instance { get; private set; }

    private float timer = 0f;
    private float initialDelay = 3.535f;
    private float interval = 7.28f;
    private float bwDuration = 1.34f;
    private bool firstTransitionDone = false;
    private List<ToggleColor> subscribers = new List<ToggleColor>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!firstTransitionDone && timer >= initialDelay)
        {
            NotifySubscribers(true);
            Invoke("ResetColor", bwDuration);
            firstTransitionDone = true;
            timer = 0f; // Reset timer for the next interval
        }
        else if (firstTransitionDone && timer >= interval)
        {
            NotifySubscribers(true);
            Invoke("ResetColor", bwDuration);
            timer = 0f; // Reset timer for the next interval
        }
    }

    public void Subscribe(ToggleColor subscriber)
    {
        if (!subscribers.Contains(subscriber))
        {
            subscribers.Add(subscriber);
        }
    }

    public void Unsubscribe(ToggleColor subscriber)
    {
        if (subscribers.Contains(subscriber))
        {
            subscribers.Remove(subscriber);
        }
    }

    void NotifySubscribers(bool toBlackAndWhite)
    {
        foreach (var subscriber in subscribers)
        {
            subscriber.SetBlackAndWhite(toBlackAndWhite);
        }
    }

    void ResetColor()
    {
        NotifySubscribers(false);
    }
}
