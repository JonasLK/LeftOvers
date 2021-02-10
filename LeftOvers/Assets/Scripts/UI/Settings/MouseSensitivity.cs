using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSensitivity : MonoBehaviour
{
    public void SetSens(float sliderValue)
    {
        PlayerPrefs.SetFloat("mouseSens", sliderValue);
    }
}
