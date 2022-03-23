using UnityEngine;

namespace Logic
{
    public class Bomb : MonoBehaviour
    {
        private const float ExplodeTime = 3f;
        private const float ExplodeRadius = 3f;
        private const float DestroyTime = 1f;
    
        [SerializeField] private GameObject _explosionPref;

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
        
            var hitColliders = new Collider2D[10];
            Physics2D.OverlapCircleNonAlloc(transform.position, ExplodeRadius, hitColliders);

            for (var i = 0; i < hitColliders.Length; i++) 
                Debug.Log(hitColliders[i]?.name);
        
            Destroy(explosion, DestroyTime);
            Destroy(gameObject);
        }
    }
}