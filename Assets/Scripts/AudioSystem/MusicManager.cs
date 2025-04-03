using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
namespace UnityUtils.AudioSystem
{
    [RequireComponent(typeof(MusicManager))]
    public class MusicManager : Singleton<MusicManager>
    {
        private const float CrossFadeTime = 1.0f;
        private float _fading;
        private AudioSource _current;
        private AudioSource _previous;
        private readonly Queue<AudioClip> _playlist = new Queue<AudioClip>();

        [SerializeField] private List<AudioClip> _initialPlaylist;
        [SerializeField] private AudioMixerGroup _musicMixerGroup;

        public float TargetVolume = 0f;

        private void Start()
        {
            foreach (AudioClip clip in _initialPlaylist)
                AddToPlaylist(clip);
        }

        public void AddToPlaylist(AudioClip clip)
        {
            _playlist.Enqueue(clip);
            if (!_current && !_previous)
                PlayNextTrack();
        }

        public void Clear()
        {
            _playlist.Clear();
        }

        public void PlayNextTrack()
        {
            if (_playlist.TryDequeue(out AudioClip nextTrack))
                Play(nextTrack);
        }

        public void Play(AudioClip clip)
        {
            if (_current && _current.clip == clip) return;

            if (_previous)
            {
                Destroy(_previous);
                _previous = null;
            }

            _previous = _current;

            _current = gameObject.GetOrAdd<AudioSource>();
            _current.clip = clip;
            _current.outputAudioMixerGroup = _musicMixerGroup;
            _current.loop = true;
            _current.volume = 0;
            _current.bypassListenerEffects = true;
            _current.Play();

            _fading = 0.001f;
        }

        private void Update()
        {
            HandleCrossFade();

            if (_current && !_current.isPlaying && _playlist.Count > 0)
                PlayNextTrack();
        }

        private void HandleCrossFade()
        {
            if (_fading <= 0f) return;

            _fading += Time.deltaTime;

            float fraction = Mathf.Clamp01(_fading / CrossFadeTime);
            float logFraction = fraction.ToLogarithmicFraction();

            if (_previous) _previous.volume = TargetVolume - logFraction;
            if (_current) _current.volume = logFraction;

            if (fraction >= TargetVolume)
            {
                _fading = 0.0f;
                if (_previous)
                {
                    Destroy(_previous);
                    _previous = null;
                }
            }
        }

        public void SetVolume(float newVolume)
        {
            TargetVolume = newVolume;
            _current.volume = newVolume;
        }
    }
}