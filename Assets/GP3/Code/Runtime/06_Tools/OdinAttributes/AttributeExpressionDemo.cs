using Sirenix.OdinInspector;
using UnityEngine;

namespace GP3._06_Tools.OdinAttributes
{
	public class AttributeExpressionDemo : MonoBehaviour
	{
		[SerializeField] private bool _someValue;
		[SerializeField] [ShowIf("@_someValue == true")] 
		private float _onlyShownIfSomeValueEqualsTrue;
	}
}