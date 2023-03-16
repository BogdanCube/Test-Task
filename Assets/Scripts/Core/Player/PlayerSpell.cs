using Base;
using Core.Spell;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Player
{
    public class PlayerSpell : MonoBehaviour
    {
        [SerializeField,Expandable] private Spell.Spell _currentSpell;
        [SerializeField] private FlyingSpell _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private SetterDirection _setter;
        private bool _isFlying;
        private FlyingSpell _flyingSpell;
        
        private void Update()
        {
            if (Input.GetMouseButton(0) && _isFlying == false)
            {
                LaunchSpell();
                _isFlying = true;
            }
        }

        private void LaunchSpell()
        {
            _flyingSpell = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
            _flyingSpell.Construct(_currentSpell,_setter);
            _flyingSpell.Init(() => _isFlying = false);
        }
        public void SetSpell(Spell.Spell spell)
        {
            _currentSpell = spell;
        }

    }
}