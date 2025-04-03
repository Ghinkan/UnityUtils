using UnityEngine;
namespace UnityUtils.EventChannels
{
    [CreateAssetMenu(fileName = "BoolEventChannel", menuName = "Events/Bool Event Channel")]
    public class BoolEventChannel : GenericEventChannel<bool> { }
}