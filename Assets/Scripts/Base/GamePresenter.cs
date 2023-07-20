using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Base
{
    public class GamePresenter : MonoBehaviour
    {
        [SerializeField] private Entity _monster;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private Button _restartButton;
        
        #region Enable / Disable
        private void OnEnable()
        {
            _monster.OnDestroy += Win;
        }
        
        private void OnDisable()
        {
            _monster.OnDestroy -= Win;
        }

        #endregion
        private void Win()
        {
            _restartButton.transform.localScale = Vector3.zero;
            _restartButton.enabled = false;
            
            _winPanel.gameObject.SetActive(true);
            _restartButton.transform.DOScale(1, 0.5f).OnComplete(() =>
            {
                _restartButton.enabled = true;
            });
        }
    }
}