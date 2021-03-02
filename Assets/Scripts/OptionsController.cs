
using UnityEngine;
using UnityEngine.UI;


public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider M_volumeSlider;
    [SerializeField] float M_DefaultValue = 0.8f;

    [SerializeField] Slider M_DifficultySlider;
    [SerializeField] float M_DefaultDifficulty = 0f;


    void Start()
    {
        M_volumeSlider.value = PlayerPrefController.GetMasterVolume();
        M_DifficultySlider.value = PlayerPrefController.GetDifficulty();

    }


    void Update()
    {
        var MusicPlayer = FindObjectOfType<MusicPlayer>();
        if(MusicPlayer)
        {
            MusicPlayer.SetVolume(M_volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("Don't Have Music Player");
        }
    }
    public void SaveAndExit()
    {
        PlayerPrefController.SetMasterVolume(M_volumeSlider .value);
        PlayerPrefController.SetDifficulty(M_DifficultySlider.value);
        LevelLoader.instance.LoadMainMenu();
    }
    public void SetDefault()
    {
        M_volumeSlider .value = M_DefaultValue;
        M_DifficultySlider.value = M_DefaultDifficulty;

    }
}
