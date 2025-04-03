using UnityEngine;
using UnityEngine.Events;
namespace UnityUtils.DetectorsTools
{
    public class CollisionDetectorTag3D : MonoBehaviour
    {
        [TagSelector] public string Tag;

        public UnityEvent OnPlayerEnter;
        public UnityEvent OnPlayerStay;
        public UnityEvent OnPlayerExit;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(Tag))
                OnPlayerEnter.Invoke();
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag(Tag))
                OnPlayerStay.Invoke();
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag(Tag))
                OnPlayerExit.Invoke();
        }
    }
}