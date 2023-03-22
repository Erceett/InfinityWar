using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        Debug.Log("horizontal = " + " " + xThrow);

        float yThrow = Input.GetAxis("Vertical");
        Debug.Log("vertical = " + " " + yThrow);

        float xValue = xThrow * Time.deltaTime * speed;
        float yValue = yThrow * Time.deltaTime * speed;

        transform.Translate(xValue, yValue , 0);
    }
}
