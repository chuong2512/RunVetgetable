using System;
using ChuongCustom;
using UnityEngine;

namespace DefaultNamespace
{
    public class Mush : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                Data.Player.Coin++;
                Destroy(gameObject);
            }
        }
    }
}