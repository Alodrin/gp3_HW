using UnityEngine;

namespace GP3._05_FSM.AI
{
	public class LookAroundState : IdleState
	{
		private float _currentTime;
		private const float LookAroundTime = 1.75f;
		
		public override IEnemyState Execute(Enemy enemy)
		{
			_currentTime += Time.deltaTime;
			if (_currentTime >= LookAroundTime)
			{
				return Enemy.PatrolState;
			}

			return base.Execute(enemy);
		}

		public override void Enter(Enemy enemy)
		{
			_currentTime = 0;
			enemy.Animator.SetTrigger(Enemy.LookAround);
		}

		public override void Exit(Enemy enemy)
		{
		}
	}
}