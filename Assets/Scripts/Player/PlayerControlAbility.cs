using System.Collections.Generic;
using UnityEngine;

public class PlayerControlAbility : MonoBehaviour
{
    [SerializeField] private List<ItemAbility> _abilitiesArray;
    [SerializeField] private List<SlotForAbility> _slotForAbilitiesArray;

    private Player _player;
    private InputHandler _inputHandler;

    public void Initialize(InputHandler inputHandler, Player player)
    {
        _inputHandler = inputHandler;
        _player = player;
    }

    private void Update()
    {
        if (_inputHandler.IsKeyPressUseAbility)
            GoToUseAbility();

    }

    public void PickUpAbility(ItemAbility itemAbility)
    {
        if (IsAlreadyLocate(itemAbility) == false)
        {
            itemAbility.GetComponent<Collider>().enabled = false;
            SetMoveAbilityOff(itemAbility);

            SlotForAbility epmtySlotForAbility = GetEmptySlot(itemAbility);
            
            itemAbility.TransformAbility.SetParent(epmtySlotForAbility.SlotTransform);
            itemAbility.transform.position = epmtySlotForAbility.transform.position;
            itemAbility.transform.rotation = _player.transform.rotation;

            _abilitiesArray.Add(itemAbility);
        }
    }

    public bool IsAlreadyLocate(ItemAbility itemAbility)
    {
        if (_abilitiesArray.Count > 0)
        {
            foreach (ItemAbility locateAbility in _abilitiesArray)
            {
                if (locateAbility.GetType() == itemAbility.GetType())
                    return true;
            }
        }

        return false;
    }

    public void Healing(int value)
    {
        _player.SetHealth(value);
    }

    public void ChangeSpeed(float value)
    {
        _player.MultiplySpeed(value);
    }

    private void GoToUseAbility()
    {
        if (_abilitiesArray.Count > 0)
        {
            foreach (ItemAbility itemAbility in _abilitiesArray)
            {
                itemAbility.UseAbility(this);

                Destroy(itemAbility.gameObject);
            }

            _abilitiesArray.Clear();
        }
        else
        {
            Debug.Log(" Нет предметов со способностями");
        }
    }

    private SlotForAbility GetEmptySlot(ItemAbility itemAbility)
    {
        SlotForAbility epmtySlotForAbility;

        foreach (SlotForAbility slotForAbility in _slotForAbilitiesArray)
        {
            if (slotForAbility.IsEmpty)
            {
                slotForAbility.FillSlot(itemAbility);

                return epmtySlotForAbility = slotForAbility;
            }
        }

        Debug.LogError($" Все слоты заняты! ");
        return null;
    }

    private void SetMoveAbilityOff(ItemAbility itemAbility)
    {
        Oscillator oscillator = itemAbility.GetComponent<Oscillator>();
        
        if (oscillator != null)
        {
            oscillator.SetOscillateOff();
        }

        Rotator rotator = itemAbility.GetComponent<Rotator>();
        if (rotator != null)
        {
            rotator.SetRotateOff();
        }
    }
}
