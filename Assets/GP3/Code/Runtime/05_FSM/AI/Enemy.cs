using Gamekit3D;
using UnityEngine;
using UnityEngine.AI;

namespace GP3._05_FSM.AI
{
	[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
	public class Enemy : MonoBehaviour
	{
		// Animator parameter
		public static readonly int Defend = Animator.StringToHash("Defend");
		public static readonly int Patrol = Animator.StringToHash("Patrol");
		public static readonly int LookAround = Animator.StringToHash("LookAround");
		public static readonly int ChasePlayer = Animator.StringToHash("ChasePlayer");
		private static readonly int Attack = Animator.StringToHash("Attack");
		
		// potential enemy states
		public static PatrolState PatrolState = new PatrolState();
		public static LookAroundState LookAroundState = new LookAroundState();
		
		[SerializeField] [Tooltip("Enemy Sight Distance in meters")]
		private float _sightDistance = 5f;
		[SerializeField] [Tooltip("Enemy Aggro Range in meters. Outside of this range, the enemy will go back to patrolling.")]
		private float _aggroRange = 15f;
		[SerializeField] [Tooltip("Patrol pints")]
		private Transform[] _patrolPoints = default;
		[SerializeField] [Tooltip("Enemy HP maximum.")]
		private float _maxHealth = 100f;
		[SerializeField] [Tooltip("The range in which the enemy can hit the player.")]
		private float _attackRange = 2f;
		[SerializeField] [Tooltip("The amount of HP a single strike is going to reduce.")]
		private float _damage;

		// reference to the player object
		public PlayerController Player => _player;
		// returns true, if the player can be seen (First check distance of sight, then check line of sight using dot product (LoS in this case only means player is in front of enemy, doesnt check for occlusion)
		public bool IsPlayerInSight => (Vector3.Distance(transform.position, _player.transform.position) < _sightDistance) && (Vector3.Dot(transform.forward, _player.transform.position) > 0);
		// range in meters for aggro, before enemy goes back to idle again
		public float AggroRange => _aggroRange;
		// points for the enemy patrol
		public Transform[] PatrolPoints => _patrolPoints;
		// the nav mesh agent component of the enemy
		public NavMeshAgent NavMeshAgent => _navMeshAgent;
		// the animator of the enemy
		public Animator Animator => _animator;
		// the current patrol point we are walking towards
		public int CurrentPatrolPointIndex => _currentPatrolPointIndex;
		
		public float AttackRange => _attackRange;
		public float Health => _health;
		public float MaxHealth => _maxHealth;
		public int NumberOfConsecutiveAttacks => _numberOfConsecutiveAttacks;
		private PlayerController _player;
		private Animator _animator;
		private NavMeshAgent _navMeshAgent;
		private IEnemyState _currentState;
		private float _health;
		private int _currentPatrolPointIndex;
		private int _numberOfConsecutiveAttacks;
		
		private void Awake()
		{
			_player = FindObjectOfType<PlayerController>();
			_animator = GetComponent<Animator>();
			_navMeshAgent = GetComponent<NavMeshAgent>();
			_currentState = PatrolState;
			_health = _maxHealth;
		}

		private void Update()
		{
			IEnemyState enemyState = _currentState.Execute(this);
			if (enemyState != _currentState)
			{
				Debug.Log($"Going from state {_currentState} to {enemyState}");
				_currentState.Exit(this);
				_currentState = enemyState;
				_currentState.Enter(this);
			}
		}
		
		public void UpdateNextPatrolPoint()
		{
			_currentPatrolPointIndex++;
			// use % operator to easily wrap around the patrol point index once we "overshoot" the index
			_currentPatrolPointIndex %= _patrolPoints.Length;
		}

		public bool CanAttackPlayer()
		{
			return Vector3.Distance(transform.position, _player.transform.position) <= _attackRange;
		}

		public void DoAttackPlayer()
		{
			_player.Damage(_damage);
			_animator.SetTrigger(Attack);
			_numberOfConsecutiveAttacks = NumberOfConsecutiveAttacks + 1;
		}
		
		public void ResetAttackCounter()
		{
			_numberOfConsecutiveAttacks = 0;
		}
	}
}