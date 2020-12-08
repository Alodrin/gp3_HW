using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace GP3._06_Tools.OdinAttributes
{
	public class GroupingAttributes : MonoBehaviour
	{
		[HorizontalGroup("Fake Vector", LabelWidth = 20)] [SerializeField]
		private float _x;
		[HorizontalGroup("Fake Vector")] [SerializeField]
		private float _y;
		[HorizontalGroup("Fake Vector")] [SerializeField]
		private float _z;
		
		[HorizontalGroup("Fake Matrix", LabelWidth = 20)]
		[VerticalGroup("Fake Matrix/Col 1")] 
		[SerializeField]
		private float _x1;
		[VerticalGroup("Fake Matrix/Col 2")] [SerializeField]
		private float _y1;
		[VerticalGroup("Fake Matrix/Col 3")] [SerializeField]
		private float _z1;
		[VerticalGroup("Fake Matrix/Col 1")] 
		[SerializeField]
		private float _x2;
		[VerticalGroup("Fake Matrix/Col 2")] [SerializeField]
		private float _y2;
		[VerticalGroup("Fake Matrix/Col 3")] [SerializeField]
		private float _z2;
		
		[FoldoutGroup("Stats", expanded: true)] [SerializeField]
		private float _maxHealth;
		[FoldoutGroup("Stats")] [SerializeField]
		private float _maxSpeed;
		[FoldoutGroup("Stats")] [SerializeField]
		private float _stamina;
		[FoldoutGroup("Stats")] [SerializeField]
		private float _mana;

		[BoxGroup("SFX")] [SerializeField]
		private AudioClip _onHit;
		[BoxGroup("SFX")] [SerializeField]
		private AudioClip _onDeath;
		[BoxGroup("SFX")] [SerializeField]
		private AudioClip _onHeal;

		[TabGroup("Settings")] [SerializeField]
		private string _name;
		[TabGroup("Settings")] [SerializeField]
		private float _damage;
		[TabGroup("Settings")] [SerializeField]
		private ParticleSystem _vfx;
		[TabGroup("Components")] [SerializeField]
		private Animator _animator;
		[TabGroup("Components")] [SerializeField]
		private Rigidbody _rigidbody;
		[TabGroup("Components")] [SerializeField]
		private NavMeshAgent _agent;

		[TabGroup("All-In-One", "Settings")] 
		[HorizontalGroup("All-In-One/Settings/Horizontal", LabelWidth = 100)]
		[VerticalGroup("All-In-One/Settings/Horizontal/C1")]
		[SerializeField]
		private int _speed;
		[VerticalGroup("All-In-One/Settings/Horizontal/C1")] [SerializeField]
		private int _attack;
		[VerticalGroup("All-In-One/Settings/Horizontal/C1")] [SerializeField]
		private int _defense;
		[VerticalGroup("All-In-One/Settings/Horizontal/C1")] [SerializeField]
		private int _luck;
		[VerticalGroup("All-In-One/Settings/Horizontal/C2")]
		[BoxGroup("All-In-One/Settings/Horizontal/C2/Resources")]
		[SerializeField]
		private int _maxHitPoints;
		[BoxGroup("All-In-One/Settings/Horizontal/C2/Resources")] [SerializeField]
		private int _maxStamina;
		[BoxGroup("All-In-One/Settings/Horizontal/C2/Resources")] [SerializeField]
		private int _maxMana;
		[TabGroup("All-In-One", "SFX")] [SerializeField]
		private AudioClip _beingHit;
		[TabGroup("All-In-One", "SFX")] [SerializeField]
		private AudioClip _dying;
		[TabGroup("All-In-One", "SFX")] [SerializeField]
		private AudioClip _beingHealed;
		[TabGroup("All-In-One", "VFX")] [SerializeField]
		private ParticleSystem _hitParticles;
		[TabGroup("All-In-One", "VFX")] [SerializeField]
		private ParticleSystem _deathParticles;
		[TabGroup("All-In-One", "VFX")] [SerializeField]
		private ParticleSystem _healParticles;
	}
}