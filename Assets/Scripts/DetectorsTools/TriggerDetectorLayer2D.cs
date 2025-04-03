using UnityEngine;
using UnityEngine.Events;
namespace UnityUtils.DetectorsTools
{
    public class TriggerDetectorLayer2D : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;

        public UnityEvent OnPlayerEnter;
        public UnityEvent OnPlayerStay;
        public UnityEvent OnPlayerExit;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_layerMask.Contains(collision.gameObject.layer))
                OnPlayerEnter.Invoke();
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (_layerMask.Contains(collision.gameObject.layer))
                OnPlayerStay.Invoke();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (_layerMask.Contains(collision.gameObject.layer))
                OnPlayerExit.Invoke();
        }
    }
}