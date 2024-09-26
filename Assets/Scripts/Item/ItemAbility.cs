using UnityEngine;

public abstract class ItemAbility : MonoBehaviour
{
    [SerializeField] protected AbilityView _abilityView;    

    public Transform TransformAbility => this.transform;    

    public abstract void UseAbility(PlayerControlAbility playerTakeAbility);    

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerControlAbility playerTakeAbility))
        {
            playerTakeAbility.PickUpAbility(this);
        }

    }

}
