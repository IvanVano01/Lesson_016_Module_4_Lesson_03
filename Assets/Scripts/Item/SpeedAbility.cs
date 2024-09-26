using UnityEngine;

public class SpeedAbility : ItemAbility
{
    [SerializeField] private float _speedMultiPlier;

    public override void UseAbility(PlayerControlAbility playerTakeAbility)
    {
        Debug.Log($"Использую способность Скорость !!!");

        playerTakeAbility.ChangeSpeed(_speedMultiPlier);

        _abilityView.PlayEffect(playerTakeAbility.transform);
    }
}
