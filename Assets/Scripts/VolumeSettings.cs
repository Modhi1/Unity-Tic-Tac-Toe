
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class VolumeSettings : MonoBehaviour
{
    public static VolumeSettings instance;
    [SerializeField] private AudioMixer mixer;

    const string Music_Mixer = "MusicVol";


    private void Awake()
    {
        //  musicSlider.onValueChanged.AddListener(SetMusicVolume);
        
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(gameObject);
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetMusicVolume(float value)
    {
        // set the volume of this music (Music_Mixer) to this value 
        mixer.SetFloat(Music_Mixer,value);
    }

    // for updating the music slider value (UI)

    public float GetSliderValue()
    {

        mixer.GetFloat(Music_Mixer, out float value);
        return value;
    }

}
