using UnityEngine;
using UnityEngine.UI;
namespace UnityUtils.AudioSystem
{
    public class SoundSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private SoundData _testSound;
        [SerializeField] private float _initVolume;
        [SerializeField] private float _timeToPlaySound = 0.5f;

        private SoundBuilder _sb;
        private float _timer;

        private void Start()
        {
            _sb = SoundManager.Instance.CreateSoundBuilder();

            if (PlayerPrefs.HasKey("SoundVolume"))
                _initVolume = PlayerPrefs.GetFloat("SoundVolume");

            SoundManager.Instance.SetVolume(_initVolume);
            _slider.SetValueWithoutNotify(_initVolume);
        }

        private void Update()
        {
            _timer += Time.deltaTime;
        }

        public void SetVolume(float newVolume)
        {
            SoundManager.Instance.SetVolume(newVolume);
            PlayerPrefs.SetFloat("SoundVolume", newVolume);
            PlayerPrefs.Save();

            if (_timer >= _timeToPlaySound)
            {
                _sb.Play(_testSound);
                _timer = 0f;
            }
        }
    }
}