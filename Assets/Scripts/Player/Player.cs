using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;
    [SerializeField] private ItemCollectorAbility itemCollectorAbility;

    private CharacterController _characterController;
    private InputHandler _inputHandler;
    private Mover _mover;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _inputHandler = new InputHandler();
        _mover = new Mover(_speed, _speedRotation, _inputHandler, _characterController, this);
        itemCollectorAbility.Initialize(_inputHandler, this);
    }

    private void Update()
    {
        _inputHandler.Update();
        _mover.Update();
    }

    public void SetHealth(int value) => _health += value;

    public void MultiplySpeed(float value)
    {
        if (value > 0)
        {
            float speed = _speed *= value;
            _mover.SetSpeed(speed);
        }
        else
        {
            Debug.LogError($" Множитель скорости меньше ноля {value}");
        }
    }
}
