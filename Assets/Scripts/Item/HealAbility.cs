using UnityEngine;

public class HealAbility : ItemAbility
{
    [SerializeField] private int _healthPoint;

    public override void UseAbility(ItemCollectorAbility itemCollectorAbility)
    {
        Debug.Log($"Использую способность Хилить !!!");

        itemCollectorAbility.Healing(_healthPoint);

        _abilityView.PlayEffect(itemCollectorAbility.transform);
    }
}
