using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public SpriteRenderer skin;

    private bool _isMoving;
    private int _currentPoint;

    public Transform[] pointMove;


    public Animator Animator;
    private static readonly int Jump = Animator.StringToHash("jump");

    public GameObject mush;
    public int tapCount = 3;

    private void NextPoint()
    {
        _currentPoint++;
        if (_currentPoint >= pointMove.Length)
        {
            _currentPoint = 0;
        }
    }

    void Start()
    {
        _currentPoint = 0;
        skin.sprite = SkinDataManager.Instance.CurrentSkin;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Move();

            tapCount++;
            if (tapCount > 4)
            {
                tapCount = 0;
                SpawnMush();
            }
        }
    }

    private void SpawnMush()
    {
        var point = pointMove[Random.Range(0, pointMove.Length)];

        Instantiate(mush, point.position, Quaternion.identity);
    }

    private void Move()
    {
        if (!_isMoving && Manager.InGame.IsPlaying)
        {
            _isMoving = true;

            Animator.SetTrigger(Jump);

            MasterAudioManager.Play2DSfx(AudioConst.Jump);
            
            NextPoint();
            transform.DOMove(pointMove[_currentPoint].position, 0.5f).SetEase(Ease.OutSine)
                .OnComplete(() => { _isMoving = false; });
        }
    }
}