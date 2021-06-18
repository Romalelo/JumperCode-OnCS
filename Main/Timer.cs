using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text time;
    public static bool stop3;
    private float startTime, timer=30f;

    void Start()
    {
        StartCoroutine(timer2());
    }

    void Update()
    {
        if (timer == 0)
        {
            stop3 = true;
        }
        time.text = timer.ToString();
    }

    IEnumerator timer2()
    {
        for (int i = 30; i != 0; i--)
        {
            yield return new WaitForSeconds(1.0f);
            timer -= 1;
        }
    }
}