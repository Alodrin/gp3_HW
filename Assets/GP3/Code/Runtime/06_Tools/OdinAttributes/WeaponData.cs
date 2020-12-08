using Sirenix.OdinInspector;
using UnityEngine;

namespace GP3._06_Tools.OdinAttributes
{
	[CreateAssetMenu(fileName = "New Weapon Data", menuName = "GP3/WeaponData", order = 200)]
	public class WeaponData : ScriptableObject
	{
		[SerializeField] private Sprite _sprite;
		[SerializeField] private string _weaponName;
		[SerializeField] private string _description;
		[SerializeField] private float _damage;
		[SerializeField] private bool _applyOverTime;
		[SerializeField] private float _duration;
		[ShowInInspector] private float DamagePerSecond => _damage / _duration;
		[SerializeField] private DamageType _damageType;

		[SerializeField] private bool _isMagical;
		[SerializeField] private float _manaUsage;
		[SerializeField] private float _staminaUsage;

		[SerializeField] private Sprite _uiSprite;
		[SerializeField] private string _displayName;
		[SerializeField] private AudioClip _onSlashSFX;
		[SerializeField] private AudioClip _onHitSFX;
		[SerializeField] private ParticleSystem _onSlashVFX;
		[SerializeField] private ParticleSystem _onHitVFX;

		public string WeaponName => _weaponName;

		public enum DamageType
		{
			Fire,
			Water,
			Ice,
			Ground,
			Poison,
		}
	}
}