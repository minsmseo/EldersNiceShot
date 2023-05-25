using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector3 moveDirection;
    private float moveSpeed = 4f;
    public GameObject stick;

    void Start()
    {
    }
    
    void Update()
    {
        bool hasControl = (moveDirection != Vector3.zero);
        if (hasControl)
        {
            transform.Translate(moveDirection * Time.deltaTime * moveSpeed);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if (input != null)
        {
            moveDirection = new Vector3(input.x, 0f, input.y);
        }
    }
    /*
    public void OnToggleStick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (stick.activeSelf == true)
            {
                stick.SetActive(false);
            }
            else
            {
                stick.SetActive(true);
            }
        }
    }
    */
}
