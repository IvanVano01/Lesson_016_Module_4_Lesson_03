using UnityEngine;

public class HealAbility : ItemAbility
{
    [SerializeField] private int _healthPoint;

    public override void UseAbility(PlayerControlAbility playerTakeAbility)
    {
        Debug.Log($"Использую способность Хилить !!!");

        playerTakeAbility.Healing(_healthPoint);

        _abilityView.PlayEffect(playerTakeAbility.transform);
    }
}
