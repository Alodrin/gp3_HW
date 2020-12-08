using UnityEngine;

namespace GP3._05_FSM.AI
{
	public class AttackState : CombatState
	{
		private float _attackStartedTime;
		private bool _didAttack;

		public override IEnemyState Execute(Enemy enemy)
		{
			if (enemy.CanAttackPlayer() && !_didAttack)
			{
				enemy.DoAttackPlayer();
				_didAttack = true;
			}

			if (_attackStartedTime + 1.75f < Time.time)
			{
				return enemy.NumberOfConsecutiveAttacks > 3 ? (IEnemyState) new DefendState() : new RepositionState();
			}
			
			return base.Execute(enemy);
		}

		public override void Enter(Enemy enemy)
		{
			_attackStartedTime = Time.time;
			enemy.Animator.ResetTrigger(Enemy.ChasePlayer);
		}

		public override void Exit(Enemy enemy)
		{
			_didAttack = false;
		}
	}
}