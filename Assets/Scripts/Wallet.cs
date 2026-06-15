using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Text _coinsText;

    private int _coins;

    public int Coins
    {
        get { return _coins; }
    }

    private void Start()
    {
        UpdateView();
    }

    public void AddCoins(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        _coins += amount;
        UpdateView();
    }

    private void UpdateView()
    {
        if (_coinsText != null)
        {
            _coinsText.text = "Coins: " + _coins;
        }
    }
}