using UnityEngine;

public class SpeedAbility : ItemAbility
{
    [SerializeField] private float _speedMultiPlier;

    public override void UseAbility(ItemCollectorAbility itemCollectorAbility)
    {
        Debug.Log($"Использую способность Скорость !!!");

        itemCollectorAbility.ChangeSpeed(_speedMultiPlier);

        _abilityView.PlayEffect(itemCollectorAbility.transform);
    }
}
