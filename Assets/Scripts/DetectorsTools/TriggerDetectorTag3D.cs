using UnityEngine;
using UnityEngine.Events;
namespace UnityUtils.DetectorsTools
{
    public class TriggerDetectorTag3D : MonoBehaviour
    {
        [TagSelector] public string Tag;

        public UnityEvent OnPlayerEnter;
        public UnityEvent OnPlayerStay;
        public UnityEvent OnPlayerExit;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tag))
                OnPlayerEnter.Invoke();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag(Tag))
                OnPlayerStay.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(Tag))
                OnPlayerExit.Invoke();
        }
    }
}