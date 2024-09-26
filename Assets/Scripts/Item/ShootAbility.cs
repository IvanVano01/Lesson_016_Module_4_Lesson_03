using UnityEngine;

public class ShootAbility : ItemAbility
{
    [SerializeField] private Transform _bulletPrefab;
    Vector3 _offset =new Vector3(0,0.5f,0);

    public override void UseAbility(PlayerControlAbility playerTakeAbility)
    {
        Debug.Log($"Использую способность Стрелять !!!");
        
        Transform positionBullet = playerTakeAbility.transform;

        Transform bulletPrefab = Instantiate(_bulletPrefab);        
        Bullet bullet = bulletPrefab.GetComponent<Bullet>();

        bullet.transform.position = positionBullet.position + _offset;       
        bullet.transform.rotation = positionBullet.transform.rotation;

        Destroy(bullet.gameObject, 5f);

        _abilityView.PlayEffect(playerTakeAbility.transform);
    }
}
