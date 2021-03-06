﻿using TMPro;
using UnityEngine;

namespace GP3._05_FSM.Quests
{
	public class QuestNPC : MonoBehaviour
	{
		[SerializeField] [Tooltip("NPC Dialogue Text")]
		private TextMeshProUGUI _npcBark = default;
		[SerializeField] [Tooltip("Item to Collect")]
		private QuestItem _questItem;
		[SerializeField] [Tooltip("Quests Icon shown available state")]
		private GameObject _availableStateMesh;
		[SerializeField] [Tooltip("Quests Icon shown quest task done state")]
		private GameObject _questTaskDoneStateMesh;

		public static QuestAvailableState QuestAvailableState = new QuestAvailableState();
		public static QuestActiveState QuestActiveState = new QuestActiveState();
		public static QuestTaskDoneState QuestTaskDoneState = new QuestTaskDoneState();
		public static QuestDoneState QuestDoneState = new QuestDoneState();
		
		private IQuestState _currentState;
		private GameObject _currentQuestMarker;
		public bool IsPlayerClose { get; private set; }
		public bool RequirementsMet => _questItem.IsCollected;
		public GameObject AvailableStateMesh => _availableStateMesh;
		public GameObject QuestTaskDoneStateMesh => _questTaskDoneStateMesh;
		public QuestItem QuestItem => _questItem;

		private void Awake()
		{
			_currentState = QuestAvailableState;
		}

		private void Update()
		{
			IQuestState nextState = _currentState.Execute(this);
			if (nextState != _currentState)
			{
				_currentState.Exit(this);
				_currentState = nextState;
				_currentState.Enter(this);
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				IsPlayerClose = true;
				ShowMessage();
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				IsPlayerClose = false;
				HideMessage();
			}
		}

		private void HideMessage()
		{
			_npcBark.alpha = 0;
		}

		private void ShowMessage()
		{
			_npcBark.alpha = 1;
		}

		public void DisplayQuestIcon(GameObject availableStateMesh)
		{
			Destroy(_currentQuestMarker);

			if (availableStateMesh != null)
			{
				_currentQuestMarker = Instantiate(availableStateMesh, transform);
			}
		}

		public void SetNPCAnswer(string answer)
		{
			_npcBark.text = answer;
		}
	}
}