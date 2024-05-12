using System;
using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;

public class CheckLose : MonoBehaviour
{
    public Collider2D _Collider;

    private void OnCollisionEnter2D(Collision2D col)
    {
        Manager.InGame.BeforeLose();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Manager.InGame.BeforeLose();
    }

    public void HideCol()
    {
        _Collider.enabled = false;
    }

    public void EnableCol()
    {
        _Collider.enabled = true;
    }
}