using System;
using Base;
using UnityEngine;

namespace Core.Spell
{
    public class FlyingSpell : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _mesh;
        [SerializeField] private Collider _collider;
        [SerializeField] private TrailRenderer _trail;
        private float _speed;
        private Spell _spell;
        private SetterDirection _setter;
        private Vector3 _direction;
        private Action _callback;

        public void Construct(Spell spell,SetterDirection setter)
        {
            _spell = spell;
            _setter = setter;
        }
        public void Init(Action callback)
        {
            _direction = new Vector3(0,0,1);
            _callback = callback;
            _mesh.material.color = _spell.Color;
            _trail.colorGradient = _spell.Gradient;
            _speed = _spell.Speed;
            _trail.startWidth = _spell.ExplosionRadius;
            transform.localScale = Vector3.one * _spell.ExplosionRadius;
            _setter.OnChangeDirection += ChangeDirection;
        }
        
        private void Update()
        {
            transform.Translate(_direction * (_speed * Time.deltaTime));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Cube cube))
            {
                _setter.OnChangeDirection -= ChangeDirection;
                _collider.enabled = false;
                _callback?.Invoke();
                CreateOverlapSphere();
                ActivateSpell();
                Destroy(gameObject);
            }
        }

        private void CreateOverlapSphere()
        {
            var radius = _spell.ExplosionRadius * 1f;
            var colliders = Physics.OverlapSphere(transform.position,radius);
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out Cube cube))
                {
                    if (!cube.Detouched)
                    {
                        cube.Detouch();
                        cube.GetComponent<Rigidbody>().AddExplosionForce(1000f, transform.position, radius);
                    }
                    else
                    {
                        cube.Destroy();
                    }
                }
            }
        }

        private void ChangeDirection(Vector2 direction)
        {
            _direction = new Vector3(direction.x * 1.5f,direction.y * 1.5f,1);
        }
        
        private void ActivateSpell()
        {
            if (_spell.IsBaseSpell)
            {
                SpawnSpell(_spell);
            }
            else
            {
                SpawnSpell(_spell.FirstParent);
                SpawnSpell(_spell.SecondParent);
            }
        }

        private void SpawnSpell(Spell spell)
        {
            Instantiate(spell.PrefabParticle, transform.position, Quaternion.identity);
        }
    }
}