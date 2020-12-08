using UnityEngine;

namespace GP3._06_Tools.UnityAttributes
{
	public class UnityAttributeDemo : MonoBehaviour
	{
		[HideInInspector] [SerializeField] 
		private float _serializedButHiddenFloatValue;
		[Header("Float Attributes")] [Range(0, 100f)] [SerializeField] [Tooltip("Determines the drop chance of this item in percent.")]
		private float _dropChancePercent;
		[Min(1.0f)] [SerializeField] private float _maximumHealth;
		[Header("String Attributes")] [Multiline(5)] [SerializeField] 
		private string _thisIsAMultilineString;
		[TextArea] [SerializeField] private string _thisIsATextAreaString;
		[Header("Color Attributes")] [ColorUsage(false, true)] [SerializeField] 
		private Color _colorNoAlphaHDR = Color.white;
		[ColorUsage(true, false)] [SerializeField] 
		private Color _colorAlphaNoHDR = Color.white;
		[Space(10)] [GradientUsage(true)] [SerializeField]
		private Gradient _aGradientWithHDRColors;
		[Header("Enum Attributes")] [SerializeField]
		private CurrencyType _currency;

		private enum CurrencyType
		{
			[InspectorName("Copper")] Small,
			[InspectorName("Silver")] Medium,
			[InspectorName("Gold")] Large,
		}
	}
}