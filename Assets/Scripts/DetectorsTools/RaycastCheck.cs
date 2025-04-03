using System.Collections;
using UnityEngine;
namespace UnityUtils.DetectorsTools
{
    public class RaycastCheck : MonoBehaviour
    {
        [SerializeField] private Transform[] _sensors;
        [SerializeField] private LayerMask _checkLayerMask;
        [SerializeField] private float _checkDistance;

        private RaycastHit2D _hit;

        private readonly Color _hitColor = Color.green;
        private readonly Color _hitMissColor = Color.red;
        private bool _stopCheck;

        private bool RaycastFromSensor(Transform sensor)
        {
            _hit = Physics2D.Raycast(sensor.position, sensor.right, _checkDistance, _checkLayerMask);

            if (_hit.collider)
            {
                Debug.DrawRay(sensor.position, sensor.right * _checkDistance, _hitColor);
                return true;
            }

            Debug.DrawRay(sensor.position, sensor.right * _checkDistance, _hitMissColor);
            return false;
        }

        public bool Check()
        {
            if (_stopCheck)
                return false;

            foreach (Transform sensor in _sensors)
                if (RaycastFromSensor(sensor))
                    return true;
            return false;
        }

        public void WaitToCheck(float stopCheckTime)
        {
            StartCoroutine(StopCheck(stopCheckTime));
        }

        private IEnumerator StopCheck(float time)
        {
            _stopCheck = true;
            yield return new WaitForSeconds(time);
            _stopCheck = false;
        }
    }
}