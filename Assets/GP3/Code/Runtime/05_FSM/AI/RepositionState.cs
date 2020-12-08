using UnityEngine;
using Random = UnityEngine.Random;

namespace GP3._05_FSM.AI
{
	public class RepositionState : CombatState
	{
		private Vector3 _nextOffsetToPlayer;

		public override IEnemyState Execute(Enemy enemy)
		{
			if (enemy.NavMeshAgent.remainingDistance > 0.5f)
			{
				enemy.NavMeshAgent.SetDestination(enemy.Player.transform.position + _nextOffsetToPlayer);
			}
			else
			{
				return new AttackState();
			}
			
			return base.Execute(enemy);
		}

		public override void Enter(Enemy enemy)
		{
			_nextOffsetToPlayer = Random.insideUnitSphere * (enemy.AttackRange * 0.75f);
			enemy.NavMeshAgent.SetDestination(enemy.Player.transform.position + _nextOffsetToPlayer);
			enemy.Animator.SetTrigger(Enemy.ChasePlayer);
		}

		public override void Exit(Enemy enemy)
		{
		}
	}
}