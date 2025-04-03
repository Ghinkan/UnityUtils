using UnityEngine;
using UnityEngine.Events;
namespace UnityUtils.DetectorsTools
{
    public class CollisionDetectorLayer3D : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;

        public UnityEvent OnPlayerEnter;
        public UnityEvent OnPlayerStay;
        public UnityEvent OnPlayerExit;

        private void OnCollisionEnter(Collision collision)
        {
            if (_layerMask.Contains(collision.gameObject.layer))
                OnPlayerEnter.Invoke();
        }

        private void OnCollisionStay(Collision collision)
        {
            if (_layerMask.Contains(collision.gameObject.layer))
                OnPlayerStay.Invoke();
        }

        private void OnCollisionExit(Collision collision)
        {
            if (_layerMask.Contains(collision.gameObject.layer))
                OnPlayerExit.Invoke();
        }
    }
}