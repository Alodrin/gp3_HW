namespace GP3._05_FSM.AI
{
	public interface IEnemyState
	{
		IEnemyState Execute(Enemy enemy);
		void Enter(Enemy enemy);
		void Exit(Enemy enemy);
	}
}