using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Monster
{
    public class HealthBarMonster : MonoBehaviour
    {
        [SerializeField] private Image _slider;
        [SerializeField] private Entity _entity;
        [SerializeField] private TextMeshProUGUI _text;

        #region Enable / Disable
        private void OnEnable()
        {
            _entity.OnUpdateCount += UpdateCount;
        }
        
        private void OnDisable()
        {
            _entity.OnUpdateCount -= UpdateCount;
        }

        #endregion
        private void UpdateCount(int count, int maxCount)
        {
            var coefficient = (float)count / maxCount;
            _text.text = count.ToString();
            _slider.DOFillAmount(coefficient, 1);
        }
    }
}