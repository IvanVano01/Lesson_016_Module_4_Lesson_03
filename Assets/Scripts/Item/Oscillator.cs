using UnityEngine;

public class Oscillator : MonoBehaviour
{
    private Vector3 _defaultPosition;
    private float _time;

    private bool _isOscillate;

    private void Awake()
    {
        _isOscillate = true;
        _defaultPosition = transform.position;
    }

    private void Update()
    {
        if (_isOscillate == false)
            return;
       
        _time += Time.deltaTime * 5; 

        transform.position = _defaultPosition + Vector3.up * Mathf.Sin(_time)/5;
    }

    public void SetOscillateOff()
    {
        _isOscillate = false;
    }
}
