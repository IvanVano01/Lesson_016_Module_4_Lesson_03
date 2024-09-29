using UnityEngine;

public abstract class ItemAbility : MonoBehaviour
{
    [SerializeField] protected AbilityView _abilityView;

    public Transform TransformAbility => this.transform;

    public abstract void UseAbility(ItemCollectorAbility playerTakeAbility);

    public void OnPickUp()
    {
        Oscillator oscillator = GetComponent<Oscillator>();

        if (oscillator != null)
            oscillator.SetOscillateOff();

        Rotator rotator = GetComponent<Rotator>();

        if (rotator != null)
            rotator.SetRotateOff();

    }
}
