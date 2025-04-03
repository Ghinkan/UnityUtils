using UnityEngine;
using UnityEngine.UI;
namespace UnityUtils.AudioSystem
{
    public class MusicSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _initVolume;

        private void Start()
        {
            if (PlayerPrefs.HasKey("MusicVolume"))
                _initVolume = PlayerPrefs.GetFloat("MusicVolume");

            MusicManager.Instance.SetVolume(_initVolume);
            _slider.SetValueWithoutNotify(_initVolume);
        }

        public void SetVolume(float newVolume)
        {
            MusicManager.Instance.SetVolume(newVolume);
            PlayerPrefs.SetFloat("MusicVolume", newVolume);
            PlayerPrefs.Save();
        }
    }
}