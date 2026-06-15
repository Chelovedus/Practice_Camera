using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    [SerializeField] private float _requiredHitForce = 7f;
    [SerializeField] private int _damage = 100;
    [SerializeField] private ParticleSystem _explosionEffect;

    private bool _isExploded;

    private void OnCollisionEnter(Collision collision)
    {
        if (_isExploded || !collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        float hitForce = collision.relativeVelocity.magnitude;

        if (hitForce < _requiredHitForce)
        {
            return;
        }

        Explode(collision.gameObject);
    }

    private void Explode(GameObject player)
    {
        _isExploded = true;

        PlayerHealth health = player.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.TakeDamage(_damage);
        }
        else
        {
            Destroy(player);
        }

        if (_explosionEffect != null)
        {
            Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}