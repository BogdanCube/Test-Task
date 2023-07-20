using Core.Player;
using Core.Spell;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class PanelCurrentSpell : MonoBehaviour
    {
        [SerializeField] private PanelChangeSpell _firstPanel;
        [SerializeField] private PanelChangeSpell _secondPanel;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private PlayerSpell _player;
        [SerializeField] private CombinatorSpell _combinator;
        #region Enable / Disable

        private void OnEnable()
        {
            _firstPanel.OnSelect += CombinationSpell;
            _secondPanel.OnSelect += CombinationSpell;
        }
        
        private void OnDisable()
        {
            _firstPanel.OnSelect -= CombinationSpell;
            _secondPanel.OnSelect -= CombinationSpell;
        }

        #endregion

        private void CombinationSpell()
        {   
            var firstSpell = _firstPanel.CurrentSpell;
            var secondSpell = _secondPanel.CurrentSpell;
            var spell = _combinator.Combination(firstSpell,secondSpell);
            
            _player.SetSpell(spell);
            _icon.sprite = spell.Icon;
            _text.text = spell.Name;
            _text.color = spell.IsBaseSpell == false ? spell.Color : Color.white;
        }
    }
}