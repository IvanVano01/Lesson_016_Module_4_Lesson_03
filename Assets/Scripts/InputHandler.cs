using UnityEngine;

public class InputHandler 
{
    private string HorizontalX = "Horizontal";
    private string HorizontalZ = "Vertical";
    
    private float _inputAxisX;
    private float _inputAxisZ;

    private Vector3 _inputDirection;

    public bool IsKeyPressUseAbility { get; private set; }

    public void Update()
    {
        _inputAxisX = Input.GetAxisRaw(HorizontalX);
        _inputAxisZ = Input.GetAxisRaw(HorizontalZ);

        _inputDirection = new Vector3(-_inputAxisZ, 0, _inputAxisX);

        IsKeyPressUseAbility = Input.GetKeyDown(KeyCode.F);        
    }

    public Vector3 InputDirection() => _inputDirection;
}
