using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatMovementTouch : MonoBehaviour
{
    public float movementSpeed = 4f;
    public float rotationSpeed = 400f;

    public GameObject fillFuelCanvas;

    private Touch _touch;

    private Vector3 _touchDown;
    private Vector3 _touchUp;

    [SerializeField] private float fuel = 100f;
    [SerializeField] private Slider fuelSlider;
    public float fuelBurnRate = 2f;
    private float currentFuel;

    private bool _dragStarted;
    private bool _isMoving;

    // Start is called before the first frame update
    void Start()
    {
        currentFuel = fuel;
    }

    // Update is called once per frame
    void Update()
    {   
        if( currentFuel <= 1)
        {
            fillFuelCanvas.SetActive(true);
            Time.timeScale = 0;
        }

        if(Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if(_touch.phase == TouchPhase.Began)
            {
                _dragStarted = true;
                _isMoving = true;
                _touchDown = _touch.position;
                _touchUp = _touch.position;
            }
        }

        if (_dragStarted)
        {
            if(_touch.phase == TouchPhase.Moved)
            {
                _touchDown = _touch.position;
            }
            if(_touch.phase == TouchPhase.Ended)
            {
                _touchDown = _touch.position;
                _isMoving = false;
                _dragStarted = false;
            }
            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), rotationSpeed * Time.deltaTime);
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
            consumeFuel();
            fuelSlider.value = currentFuel / fuel;
        }
    }

    Quaternion CalculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
        return temp;
    }

    Vector3 CalculateDirection()
    {
        Vector3 temp = (_touchDown - _touchUp).normalized;
        temp.z = temp.y;
        temp.y = 0;
        return temp;
    }
    void consumeFuel()
    {
        currentFuel -= fuelBurnRate * Time.deltaTime;
    }

    public void fillFuel()
    {
        currentFuel = 100f;
        Time.timeScale = 1f;
        fillFuelCanvas.SetActive(false);
    }
}
