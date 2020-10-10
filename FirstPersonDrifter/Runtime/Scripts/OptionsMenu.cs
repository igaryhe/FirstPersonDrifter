using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu: MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Slider foVSlider;
    public Slider sensitivitySlider;
    public Toggle invertYToggle;
    
    private MouseLook player;
    private MouseLook cam;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<MouseLook>();
        cam = Camera.main.GetComponent<MouseLook>();
    }

    public void OnBack()
    {
        pauseMenuUI.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SetSensitivity(float sensitivity)
    {
        player.sensitivity = sensitivity;
        cam.sensitivity = sensitivity;
    }

    public void SetFoV(float fov)
    {
        Camera.main.fieldOfView = fov;
    }

    public void SetInvertY(bool invert)
    {
        cam.invertY = invert;
    }

    public void OnReset()
    {
        sensitivitySlider.value = 9;
        SetSensitivity(9);
        foVSlider.value = 70;
        SetFoV(70);
        invertYToggle.isOn = false;
        SetInvertY(false);
    }
}