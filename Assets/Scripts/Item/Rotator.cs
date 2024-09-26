using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float _rotateSpeed = 50f;

    private bool _isRotate;

    private void Awake()
    {
        _isRotate = true;
    }

    private void Update()
    {
        if (_isRotate == false)
            return;

        transform.Rotate(Vector3.up, Time.deltaTime * _rotateSpeed);
    }

    public void  SetRotateOff()
    {
        _isRotate=false;
    }
}
