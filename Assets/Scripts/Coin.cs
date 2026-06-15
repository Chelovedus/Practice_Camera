using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value = 1;

    private bool _isCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (_isCollected || !other.CompareTag("Player"))
        {
            return;
        }

        Wallet wallet = other.GetComponent<Wallet>();

        if (wallet == null)
        {
            return;
        }

        _isCollected = true;
        wallet.AddCoins(_value);

        Destroy(gameObject);
    }
}