using UnityEngine;

public class MovementParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;

    private bool _isPlaying;

    private void Awake()
    {
        if (_particles == null)
        {
            _particles = GetComponent<ParticleSystem>();
        }
    }

    public void SetMoving(bool isMoving)
    {
        if (_particles == null)
        {
            return;
        }

        if (isMoving && !_isPlaying)
        {
            _particles.Play();
            _isPlaying = true;
        }
        else if (!isMoving && _isPlaying)
        {
            _particles.Stop();
            _isPlaying = false;
        }
    }
}