using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class IconSpell : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;
        private MenuSpell _menu;
        private Spell.Spell _spell;

        #region Enable / Disable

        private void OnEnable()
        {
            _button.onClick.AddListener(Select);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Select);
        }

        #endregion
        public void Load(Spell.Spell spell, MenuSpell menu)
        {
            _spell = spell;
            _menu = menu;
            _image.sprite = spell.Icon;
        }

        private void Select()
        {
            _menu.SetSpell(_spell);
        }
    }
}