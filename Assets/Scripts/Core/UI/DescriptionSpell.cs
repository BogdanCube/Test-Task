using System.Globalization;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class DescriptionSpell : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private Image _icon;
        [SerializeField] private Image _slider;
        [SerializeField] private TextMeshProUGUI _textExplosion;
        [SerializeField] private TextMeshProUGUI _textDescription;

        public void Load(Spell.Spell spell)
        {
            _name.text = "Name: " + spell.Name;
            _icon.sprite = spell.Icon;
            var coefficient = spell.ExplosionRadius / 5;
            _slider.DOFillAmount(coefficient, 0.2f);
            _textExplosion.text = spell.ExplosionRadius.ToString(CultureInfo.InvariantCulture);
            _textDescription.text = spell.IsBaseSpell ? "Description:  base spell" 
                : $"Description:  {spell.FirstParent.Name} + {spell.SecondParent.Name}";
        }
    }
}