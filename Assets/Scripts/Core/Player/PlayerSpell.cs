using NaughtyAttributes;
using UnityEngine;

namespace Core.Player
{
    public class PlayerSpell : MonoBehaviour
    {
        [SerializeField] private RaycastDetoucher _detoucher;
        [SerializeField,Expandable] private Spell.Spell _starSpell;
        private Spell.Spell _currentSpell;
        
        #region Enable / Disable
        private void OnEnable()
        {
            _detoucher.OnDetouch += ActivateSpell;
        }
        
        private void OnDisable()
        {
            _detoucher.OnDetouch -= ActivateSpell;
        }

        #endregion

        private void Start()
        {
            SetSpell(_starSpell);
        }

        public void SetSpell(Spell.Spell spell)
        {
            _currentSpell = spell;
            _detoucher.SetRadius(_currentSpell.ExplosionRadius);
        }

        private void ActivateSpell(Vector3 position)
        {
            if (_currentSpell.IsBaseSpell)
            {
                SpawnSpell(_currentSpell,position);
            }
            else
            {
                SpawnSpell(_currentSpell.FirstParent,position);
                SpawnSpell(_currentSpell.SecondParent,position);
            }
        }

        private void SpawnSpell( Spell.Spell spell, Vector3 position)
        {
            var particle = Instantiate(spell.PrefabParticle, position, Quaternion.identity);
            Destroy(particle, 5);
        }
    }
}