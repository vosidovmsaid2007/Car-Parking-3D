using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearboxSettings : MonoBehaviour
{
    [SerializeField] private GameObject D_button;
    [SerializeField] private GameObject R_button;

    [SerializeField] private RawImage BackCamMirror;

    public void showD()
    {
        R_button.SetActive(false);
        D_button.SetActive(true);

        gameObject.GetComponent<GameManager>().Reverse = false;

        BackCamMirror.enabled = false;
    }

    public void showR()
    {
        R_button.SetActive(true);
        D_button.SetActive(false);

        gameObject.GetComponent<GameManager>().Reverse = true;

        BackCamMirror.enabled = true;
    }
}
