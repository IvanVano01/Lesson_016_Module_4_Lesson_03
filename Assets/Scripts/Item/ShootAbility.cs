using UnityEngine;

public class ShootAbility : ItemAbility
{
    [SerializeField] private Bullet _bulletPrefab;

    public override void UseAbility(ItemCollectorAbility itemCollectorAbility)
    {
        Debug.Log($"Использую способность Стрелять !!!");
        
        Vector3 positionBullet = itemCollectorAbility.ShootPointPosition;

        Bullet bullet = Instantiate(_bulletPrefab);

        bullet.Launch(positionBullet,transform.rotation);       

        Destroy(bullet.gameObject, 5f);

        _abilityView.PlayEffect(itemCollectorAbility.transform);
    }
}
