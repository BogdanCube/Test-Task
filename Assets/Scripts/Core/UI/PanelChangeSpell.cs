using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class PanelChangeSpell : MonoBehaviour
    {
        [SerializeField] private Spell.Spell _currentSpell;
        [SerializeField] private GameObject _listSpell;
        [SerializeField] private Button _button;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _text;
        public event Action OnSelect;
        public Spell.Spell CurrentSpell => _currentSpell;

        #region Enable / Disable

        private void OnEnable()
        {
            _button.onClick.AddListener(ToggleList);
        }
        
        private void OnDisable()
        {
            _button.onClick.RemoveListener(ToggleList);
        }

        #endregion

        private void Start()
        {
           SelectSpell(_currentSpell);
        }

        public void SelectSpell(Spell.Spell spell)
        {
            _icon.sprite = spell.Icon;
            _text.text = spell.Name;
            _listSpell.SetActive(false);
            _currentSpell = spell;
            OnSelect?.Invoke();
        }
        private void ToggleList()
        {
            _listSpell.SetActive(!_listSpell.activeSelf);
        }
        
    }
}