﻿using UnityEngine;

namespace GP3._05_FSM.Quests
{
	public interface IQuestState
	{
		IQuestState Execute(QuestNPC npc);
		void Enter(QuestNPC npc);
		void Exit(QuestNPC npc);
	}
	
	public class QuestAvailableState : IQuestState
	{
		public IQuestState Execute(QuestNPC npc)
		{
			if (Input.GetMouseButtonDown(0) && npc.IsPlayerClose)
			{
				return QuestNPC.QuestActiveState;
			}
			
			return QuestNPC.QuestAvailableState;
		}

		public void Enter(QuestNPC npc)
		{
			npc.DisplayQuestIcon(npc.AvailableStateMesh);
			npc.SetNPCAnswer("Hey you! Go get that item for me, would ya?");
		}

		public void Exit(QuestNPC npc)
		{
			npc.DisplayQuestIcon(null);
			npc.SetNPCAnswer("");
		}
	}
	
	public class QuestActiveState : IQuestState
	{
		public IQuestState Execute(QuestNPC npc)
		{
			if (npc.RequirementsMet)
			{
				return QuestNPC.QuestTaskDoneState;
			}

			return QuestNPC.QuestActiveState;
		}

		public void Enter(QuestNPC npc)
		{
			npc.QuestItem.Activate();
			npc.SetNPCAnswer("Remember to bring me my item please");
		}

		public void Exit(QuestNPC npc)
		{
			npc.SetNPCAnswer("");
		}
	}
	
	public class QuestTaskDoneState : IQuestState
	{
		public IQuestState Execute(QuestNPC npc)
		{
			if (npc.IsPlayerClose && Input.GetMouseButtonDown(0))
			{
				return QuestNPC.QuestDoneState;
			}

			return QuestNPC.QuestTaskDoneState;
		}

		public void Enter(QuestNPC npc)
		{
			npc.DisplayQuestIcon(npc.QuestTaskDoneStateMesh);
			npc.SetNPCAnswer("Ay what a great finding! Myyyy precious");
		}

		public void Exit(QuestNPC npc)
		{
			npc.DisplayQuestIcon(null);
			npc.SetNPCAnswer("");
		}
	}
	
	public class QuestDoneState : IQuestState
	{
		public IQuestState Execute(QuestNPC npc)
		{
			return QuestNPC.QuestDoneState;
		}

		public void Enter(QuestNPC npc)
		{
			npc.SetNPCAnswer("My precious..");
		}

		public void Exit(QuestNPC npc)
		{
		}
	}
}