using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public float damper = 1f;
    public Camera MainCamera;

    private Transform _localTransform; //Unity access has overhead
    private float _cameraVerticalAngle = 0f;
    private LockUpdate _locker;

    // Start is called before the first frame update
    void Awake()
    {
        _localTransform = transform;
        if (MainCamera == null) Debug.LogError("Assign Main Camera to player look at script");

        LockCursor();
        _locker = new LockUpdate();
    }

    private void ToggleCursor()
    {
        if (_locker.Lock) UnlockCursor();
        else LockCursor();
    }

    private static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private static void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _locker.ToggleLock();
            ToggleCursor();
        }
        if (_locker.Lock) return;
        HandleRotation();
    }

    private void HandleRotation()
    {
        var horizontal = UpdateAxies(out var vertical);

        RotatePlayerY(horizontal);
        RotateCameraX(vertical);
    }

    private void RotateCameraX(float vertical)
    {
        _cameraVerticalAngle += vertical;
        _cameraVerticalAngle = Mathf.Clamp(_cameraVerticalAngle, -89f, 89f);

        MainCamera.transform.localEulerAngles = new Vector3(_cameraVerticalAngle, 0f, 0f);
    }

    private void RotatePlayerY(float horizontal)
    {
        _localTransform.Rotate(0f, horizontal, 0f, Space.Self);
    }

    private float UpdateAxies(out float vertical)
    {
        float horizontal = Input.GetAxisRaw("Mouse X") * damper;
        vertical = -1 * Input.GetAxisRaw("Mouse Y") * damper;
        return horizontal;
    }
}
