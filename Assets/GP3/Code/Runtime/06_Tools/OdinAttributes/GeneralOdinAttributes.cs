using Sirenix.OdinInspector;
using UnityEngine;

namespace GP3._06_Tools.OdinAttributes
{
	public class GeneralOdinAttributes : MonoBehaviour
	{
		[Title("General Character Information")] 
		// this value is not serialized, but drawn because of the attribute
		[ShowInInspector]
		private string _characterName = "Peter Parker";
		// this value is serialized but not drawn because of the attribute
		[HideInInspector] 
		[SerializeField]
		private string _superHeroName = "Spiderman";
		[SerializeField] private bool _showCharacterDescription = true;
		[ShowIf("_showCharacterDescription")] [TextArea] [SerializeField]
		private string _characterDescription;
		[HideIf("_showCharacterDescription")] [SerializeField]
		private string _characterTraits;
		[Title("Stats")] [SerializeField]
		private bool _allowEditMovementSpeed;
		[EnableIf("_allowEditMovementSpeed")] [SerializeField]
		private float _movementSpeed;
		[ReadOnly] [SerializeField] private float _damageValue = 24.5f;
		[SerializeField] [InfoBox("This value determines the drop chance of the item in percent. You cant insert negative numbers here.")]
		private float _aFloatWithExplanation;

		[SerializeField] [EnumToggleButtons] private EnemyType _enemyType = EnemyType.Beast;

		private enum EnemyType
		{
			Flying,
			Ground,
			Humanoid,
			Beast,
		}
	}
}