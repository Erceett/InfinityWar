using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    [SerializeField] float positionFactor = -2f;
    [SerializeField] float controlFactor = -15f;

    float xThrow, yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionFactor + yThrow * controlFactor;
        float yaw = transform.localPosition.x * -positionFactor;
        float roll = xThrow * controlFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        float xOffset = xThrow * Time.deltaTime * speed;
        float newXPos = transform.localPosition.x + xOffset;
        float clampedXPoss = Mathf.Clamp(newXPos, -xRange, xRange);

        yThrow = Input.GetAxis("Vertical");
        float yOffset = yThrow * Time.deltaTime * speed;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedYPoss = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPoss, clampedYPoss, transform.localPosition.z);
    }
}
