using UnityEngine;

public class AbilityView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleEffect;

    [SerializeField] private float Vremen;

    public void PlayEffect(Transform transform)
    {
        float timeLife = 0.5f;

        if (_particleEffect != null)
        {
            ParticleSystem particleeEffect = Instantiate(_particleEffect, transform);
            particleeEffect.Play();
            Destroy(particleeEffect.gameObject, timeLife);
        }
        else
        {
            Debug.LogError($" Отсутствует ссылка на эффект {_particleEffect}");
        }
    }
}
