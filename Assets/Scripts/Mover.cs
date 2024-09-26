using UnityEngine;


public class Mover 
{
    private float _speed;
    private float _speedRotation;
    private float _deadZone = 0.1f;

    private InputHandler _inputHandler;
    private CharacterController _characterController;
    private Player _player;

    public Mover(float speed, float speedRotation, InputHandler inputHandler, CharacterController characterController, Player player)
    {
        _speed = speed;
        _speedRotation = speedRotation;
        _inputHandler = inputHandler;
        _characterController = characterController;
        _player = player;
    }

    public void Update()
    {
        Vector3 direction = _inputHandler.InputDirection();

        _characterController.Move(direction * _speed * Time.deltaTime);

        if (direction.magnitude > _deadZone)
            Rotate(direction);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void Rotate(Vector3 direction)
    {
        Vector3 rot = new(direction.x, 0, direction.z);

        Quaternion lookRotation = Quaternion.LookRotation(rot.normalized);

        _player.transform.rotation = Quaternion.RotateTowards(_player.transform.rotation, lookRotation, _speedRotation * Time.deltaTime);
    }
}
