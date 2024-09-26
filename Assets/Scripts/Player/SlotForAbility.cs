using UnityEngine;

public class SlotForAbility : MonoBehaviour
{
    private ItemAbility _itemAbility;

    public bool IsEmpty
    {
        get
        {
            if (_itemAbility == null)
                return true;

            if (_itemAbility.gameObject == null)
                return true;

            return false;
        }
    }

    public Transform SlotTransform => transform;

    public void FillSlot(ItemAbility itemAbility)
    {
        _itemAbility = itemAbility;
    }
}
