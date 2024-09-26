using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 Direction;

    private float _velocity = 20f;    

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 direction = Vector3.forward;
        transform.Translate(direction * _velocity * Time.deltaTime);
    }
}
