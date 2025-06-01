using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider audioSlider;
    public Toggle sfxToggle;
    public Toggle musicToggle;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        audioSlider.value = savedVolume;
        Debug.Log("Saved volume: " + savedVolume);

        setVolume(savedVolume);

        bool sfxEnabled = PlayerPrefs.GetInt("SFX Toggle", 1)==1;
        sfxToggle.isOn = sfxEnabled;
        setSFX(sfxEnabled);

        bool musicEnabled = PlayerPrefs.GetInt("Music Toggle", 1)==1;
        musicToggle.isOn = musicEnabled;
        setMusic(musicEnabled);
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
    public void setSFX(bool isOn)
    {
        if (!isOn)
        {
            audioMixer.SetFloat("SFX", -80);
        }
        else
        {
            audioMixer.SetFloat("SFX", 0);
        }
        PlayerPrefs.SetInt("SFX Toggle", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void setMusic(bool isOn)
    {
        if (!isOn)
        {
            audioMixer.SetFloat("Music", -80);
        }
        else
        {
            audioMixer.SetFloat("Music", 0);
        }
        PlayerPrefs.SetInt("Music Toggle", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void Back()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonPress);
        SceneManager.LoadScene("MainMenu");
    }
}
