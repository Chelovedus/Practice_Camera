using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    private int _currentHealth;
    private bool _isDead;

    public int CurrentHealth
    {
        get { return _currentHealth; }
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (_isDead || damage <= 0)
        {
            return;
        }

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        if (_isDead)
        {
            return;
        }

        _isDead = true;
        Destroy(gameObject);
    }
}