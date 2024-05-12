using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Knife : MonoBehaviour
{
    public DOTweenAnimation _Tween;


    public int min = 1, max = 2;

    public Tween t;

    private void Start()
    {
        _Tween.DOPause();
    }

    public void Play()
    {
        _Tween.DOPlay();
        t = DOVirtual.DelayedCall(Random.Range(2, 4), () => { _Tween.duration = Random.Range(min, max); }).SetLoops(-1);
    }

    public void Stop()
    {
        t.Kill();
    }
}