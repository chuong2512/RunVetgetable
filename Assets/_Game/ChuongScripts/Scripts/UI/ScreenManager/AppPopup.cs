using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ChuongCustom
{
    public abstract class AppPopup : BasePopup
    {
        [SerializeField] private Button _closeBtn;

        public override void OnOpen()
        {
            base.OnOpen();
        }

        protected virtual void Start()
        {
            _closeBtn?.onClick.AddListener(Back);
        }
    }
}