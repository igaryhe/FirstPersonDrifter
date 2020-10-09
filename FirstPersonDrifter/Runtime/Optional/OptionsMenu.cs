using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu: MonoBehaviour
{
    public GameObject PauseMenuUI;
    private MouseLook Player;
    private MouseLook Cam;
    public Slider FoVSlider;
    public Slider SensitivitySlider;
    public Toggle InvertYToggle;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<MouseLook>();
        Cam = Camera.main.GetComponent<MouseLook>();
    }

    public void OnBack()
    {
        PauseMenuUI.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SetSensitivity(float sensitivity)
    {
        Player.SetSensitivity(sensitivity);
        Cam.SetSensitivity(sensitivity);
    }

    public void SetFoV(float fov)
    {
        Camera.main.fieldOfView = fov;
    }

    public void SetInvertY(bool invert)
    {
        Cam.invertY = invert;
    }

    public void OnReset()
    {
        SensitivitySlider.value = 9;
        SetSensitivity(9);
        FoVSlider.value = 70;
        SetFoV(70);
        InvertYToggle.isOn = false;
        SetInvertY(false);
    }
}