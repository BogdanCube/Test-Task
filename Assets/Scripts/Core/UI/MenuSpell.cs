using Core.Player;
using UnityEngine;

namespace Core.UI
{
    public class MenuSpell : MonoBehaviour
    {
        [SerializeField] private Spell.Spell[] _spells;
        [SerializeField] private RectTransform _parent;
        [SerializeField] private IconSpell _prefab;
        [SerializeField] private DescriptionSpell _description;
        [SerializeField] private PlayerSpell _player;
        private Spell.Spell _currentSpell;
        private bool _isLoad;

        public void Open()
        {
            if (_isLoad == false)
            {
                Load();
                _description.Load(_spells[0]);
            }
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
        public void SetSpell(Spell.Spell spell)
        {
            _description.Load(spell);
            _player.SetSpell(spell);
        }
        private void Load()
        {
            foreach (var spell in _spells)
            {
                var icon = Instantiate(_prefab, _parent);
                icon.Load(spell,this);
            }

            _isLoad = true;
        }
    }
}