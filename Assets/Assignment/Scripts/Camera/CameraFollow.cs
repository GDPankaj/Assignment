using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements.Experimental;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _player;
    Vector3 currentMousePosition;
    Vector3 newMousePosition;
    Vector3 currentTouchPosition;
    Vector3 newTouchPosition;
    [SerializeField]const float Screen_Half_Width = 0.35f;

    void OnEnable()
    {
        GameEvents.Instance.AllShapesCollected.AddListener(DisableCameraController);
    }
    void OnDisable()
    {

    }
    void Start()
    {
        SetCameraPosition();
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            HandleMouseInput();
        }
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            HandleTouchInput();
        }
        else
        { HandleMouseInput(); }
        
    }
    // Update is called once per frame
    void LateUpdate()
    {
        SetCameraPosition();
    }

    void SetCameraPosition()
    {
        transform.position = _player.transform.position;
    }

    void RotateCamera(float mouseValue)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseValue, transform.rotation.eulerAngles.z);
    }

    void DisableCameraController()
    {
        transform.GetComponent<CameraFollow>().enabled = false;
    }

    void HandleMouseInput() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentMousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition).x);
        }

        if (Input.GetMouseButton(0))
        {
            newMousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            RotateCamera((newMousePosition.x - currentMousePosition.x) * 180f * Time.deltaTime);
            //Debug.Log("HandlingMouseInput");
        }
    }

    void HandleTouchInput()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // Check if the touch phase is Began or Moved
            if (touch.phase == TouchPhase.Began)
            {
                currentTouchPosition = Camera.main.ScreenToViewportPoint(touch.position);
            }

            if (touch.phase == TouchPhase.Moved)
            {
                newTouchPosition = Camera.main.ScreenToViewportPoint(touch.position);

                // Only allow rotation if touch is on the right side of the screen
                if (currentTouchPosition.x > 0.35f)
                {
                    RotateCamera((newTouchPosition.x - currentTouchPosition.x) * 180f * Time.deltaTime);
                    //Debug.Log("HandlingTouchInput");
                }
            }
        }
    }
}
