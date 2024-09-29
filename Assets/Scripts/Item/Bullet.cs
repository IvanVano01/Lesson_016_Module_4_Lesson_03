using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _velocity = 20f;    

    private bool _isMoving;

    private void Update()
    {
        if (_isMoving)
            Move();
    }

    public void Launch(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;

        _isMoving = true;
    }

    private void Move()
    {
        Vector3 direction = Vector3.forward;
        transform.Translate(direction * _velocity * Time.deltaTime);
    }

}
