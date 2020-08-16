using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetWindow : MonoBehaviour
{
    //Handles confirmation window when reseting the map
    public GameObject window;
    void Start()
    {
        CloseWindow();
    }
    public void OpenWindow()
    {
        window.SetActive(true);
    }
    public void CloseWindow()
    {
        window.SetActive(false);
    }
}
