using UnityEngine;
using UnityEngine.Events;
namespace UnityUtils.DetectorsTools
{
    public class TriggerDetectorLayer3D : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;

        public UnityEvent OnPlayerEnter;
        public UnityEvent OnPlayerStay;
        public UnityEvent OnPlayerExit;

        private void OnTriggerEnter(Collider other)
        {
            if (_layerMask.Contains(other.gameObject.layer))
                OnPlayerEnter.Invoke();
        }

        private void OnTriggerStay(Collider other)
        {
            if (_layerMask.Contains(other.gameObject.layer))
                OnPlayerStay.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (_layerMask.Contains(other.gameObject.layer))
                OnPlayerExit.Invoke();
        }
    }
}