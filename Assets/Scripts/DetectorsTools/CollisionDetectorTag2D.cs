using UnityEngine;
using UnityEngine.Events;
namespace UnityUtils.DetectorsTools
{
    public class CollisionDetectorTag2D : MonoBehaviour
    {
        [TagSelector] public string Tag;

        public UnityEvent OnPlayerEnter;
        public UnityEvent OnPlayerStay;
        public UnityEvent OnPlayerExit;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Tag))
                OnPlayerEnter.Invoke();
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Tag))
                OnPlayerStay.Invoke();
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Tag))
                OnPlayerExit.Invoke();
        }
    }
}