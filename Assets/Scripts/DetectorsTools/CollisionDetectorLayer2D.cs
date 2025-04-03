using UnityEngine;
using UnityEngine.Events;
namespace UnityUtils.DetectorsTools
{
    public class CollisionDetectorLayer2D : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;

        public UnityEvent OnPlayerEnter;
        public UnityEvent OnPlayerStay;
        public UnityEvent OnPlayerExit;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_layerMask.Contains(collision.gameObject.layer))
                OnPlayerEnter.Invoke();
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (_layerMask.Contains(collision.gameObject.layer))
                OnPlayerStay.Invoke();
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (_layerMask.Contains(collision.gameObject.layer))
                OnPlayerExit.Invoke();
        }
    }
}