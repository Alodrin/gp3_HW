using UnityEngine;

namespace GP3._05_FSM.AI
{
	public class DefendState : CombatState
	{
		private float _timeInState;
		private const float StateDuration = 2f;

		public override IEnemyState Execute(Enemy enemy)
		{
			_timeInState += Time.deltaTime;
			if (_timeInState >= StateDuration)
			{
				return new AttackState();
			}
			
			return base.Execute(enemy);
		}

		public override void Enter(Enemy enemy)
		{
			_timeInState = 0;
			enemy.ResetAttackCounter();
			enemy.Animator.SetTrigger(Enemy.Defend);
		}

		public override void Exit(Enemy enemy)
		{
		}
	}
}