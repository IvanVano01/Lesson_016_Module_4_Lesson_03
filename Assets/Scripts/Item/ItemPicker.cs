using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] private ItemCollectorAbility _playerControlAbility;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ItemAbility itemAbility))
        {
            _playerControlAbility.PickUpAbility(itemAbility);
        }
    }
}
