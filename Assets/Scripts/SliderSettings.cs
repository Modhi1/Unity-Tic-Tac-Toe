
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SliderSettings : MonoBehaviour
{

    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        float value = VolumeSettings.instance.GetSliderValue();

        musicSlider.value = value;
    }

    public void OnSliderValueChanged(float value)
    {

        VolumeSettings.instance.SetMusicVolume(value);

    }
}