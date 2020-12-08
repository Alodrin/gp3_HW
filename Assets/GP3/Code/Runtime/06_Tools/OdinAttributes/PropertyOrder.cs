using Sirenix.OdinInspector;
using UnityEngine;

namespace GP3._06_Tools.OdinAttributes
{
    public class PropertyOrder : MonoBehaviour
    {
        [PropertyOrder(1)] public int Second;

        [InfoBox("PropertyOrder is used to change the order of properties in the inspector.")]
        [PropertyOrder(-1)]
        public int First;
    }
}
