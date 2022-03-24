using Logic.UniversalComponents;
using UnityEngine;

namespace Logic.BombLogic
{
    public class Bomb : MonoBehaviour
    {
        private const float ExplodeTime = 2f;
        private const float ExplodeRadius = 0.65f;
        private const float DestroyTime = 1f;
    
        [SerializeField] private GameObject _explosionPref;
        [SerializeField] private LayerMask _layerMask;
        private Collider2D[] _hits = new Collider2D[3];
        private float _counter;

        private void Update()
        {
            _counter += Time.deltaTime;

            if (_counter >= ExplodeTime)
                Explode();
        }

        private void Explode()
        {
            var explosion = Instantiate(_explosionPref, transform.position, Quaternion.identity);
            var hitCount = Physics2D.OverlapCircleNonAlloc(transform.position, ExplodeRadius, _hits, _layerMask);

            if (hitCount > 0)
                for (var i = 0; i < hitCount; i++)
                {
                    if (_hits[i] == null) 
                        return;

                    var health = _hits[i].GetComponentInChildren<Health>();
                    
                    if (health == null)
                        return;
                    
                    health.TakeOneDamage();
                }
        
            Destroy(explosion, DestroyTime);
            Destroy(gameObject);
        }
    }
}