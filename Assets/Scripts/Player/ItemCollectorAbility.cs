using System.Collections.Generic;
using UnityEngine;

public class ItemCollectorAbility : MonoBehaviour
{
    [SerializeField] private List<SlotForAbility> _slotForAbilitiesArray;
    [SerializeField] private Transform _shootPoint;

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

    public Vector3 ShootPointPosition => _shootPoint.position;

    public void PickUpAbility(ItemAbility itemAbility)
    {
        if (IsAlreadyLocate(itemAbility) == false && IsFreeSlot())
        {
            itemAbility.GetComponent<Collider>().enabled = false;
            itemAbility.OnPickUp();

            SlotForAbility epmtySlotForAbility = GetEmptySlot(itemAbility);

            itemAbility.TransformAbility.SetParent(epmtySlotForAbility.SlotTransform);
            itemAbility.transform.position = epmtySlotForAbility.transform.position;
            itemAbility.transform.rotation = _player.transform.rotation;
        }
    }

    public bool IsAlreadyLocate(ItemAbility itemAbility)
    {
        foreach (SlotForAbility slotForAbility in _slotForAbilitiesArray)
        {
            if (slotForAbility.IsAlreadyExists(itemAbility))
                return true;
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
        bool isAllSlotEmpty = true;

        foreach (SlotForAbility slotForAbility in _slotForAbilitiesArray)
        {
            if (slotForAbility.IsEmpty == false)
            {
                ItemAbility itemAbility = slotForAbility.GetComponentInChildren<ItemAbility>();
                slotForAbility.ClearFieldAbility();

                itemAbility.UseAbility(this);
                Destroy(itemAbility.gameObject);

                isAllSlotEmpty = false;
            }
        }

        if (isAllSlotEmpty)
            Debug.Log(" Нет предметов со способностями");

    }

    private bool IsFreeSlot()
    {
        foreach (SlotForAbility slotForAbility in _slotForAbilitiesArray)
        {
            if (slotForAbility.IsEmpty)
                return true;
        }

        return false;
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
    
}
