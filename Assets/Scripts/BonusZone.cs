using UnityEngine;

public class BonusZone : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _playerInsideParameter = "IsPlayerInside";

    private void Awake()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetPlayerInside(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetPlayerInside(false);
        }
    }

    private void SetPlayerInside(bool isInside)
    {
        if (_animator != null)
        {
            _animator.SetBool(_playerInsideParameter, isInside);
        }
    }
}