using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace ChuongCustom
{
    public enum State
    {
        Start,
        Playing,
        Lose,
    }

    public class InGameManager : Singleton<InGameManager>
    {
        [SerializeField] public int PriceToPrice = 1;

        public State _gameState;

        public Knife Knife1, Knife2;

        public Tween Tween;

        public State GameState
        {
            get => _gameState;
            set
            {
                _gameState = value;
                switch (_gameState)
                {
                    case State.Start:
                        Tween.Pause();
                        Time.timeScale = 1;
                        break;
                    case State.Playing:
                        Time.timeScale = 1;
                        Tween = DOVirtual.DelayedCall(1f, () => { ScoreManager.Score += 1; }).SetTarget(transform)
                            .SetLoops(-1);
                        Knife1.Play();
                        Knife2.Play();
                        break;
                    case State.Lose:
                        Tween.Kill();
                        Knife1.Stop();
                        Knife2.Stop();
                        Time.timeScale = 0;
                        break;
                }
            }
        }

        private void OnDestroy()
        {
            Time.timeScale = 1;
        }

        public bool IsPlaying => _gameState != State.Lose;

        private void Start()
        {
            ScoreManager.Reset();
            GameState = State.Start;
        }

        public void Win()
        {
            Manager.ScreenManager.OpenScreen(ScreenType.Result);
            //todo:
        }

        public void Lose()
        {
            GameState = State.Lose;
            Manager.ScreenManager.OpenScreen(ScreenType.Lose);
            //todo:
        }

        public void BeforeLose()
        {
            GameState = State.Lose;
            Manager.ScreenManager.OpenScreen(ScreenType.BeforeLose);
            MasterAudioManager.Play2DSfx(AudioConst.Die);
            
            //todo:
        }

        public void Retry()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void Continue()
        {
            //continue

            //todo:

            StartGame();
        }

        public void StartGame()
        {
            GameState = State.Playing;
        }
    }
}