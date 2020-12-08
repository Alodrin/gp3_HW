using System;
using GP3._06_Tools.OdinAttributes;
using UnityEditor;
using UnityEngine;

namespace GP3.Code.Tools.Odin
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(WeaponData))]
	public class WeaponDataInspector : Editor
	{
		private SerializedProperty _weaponSpriteProperty;
		private SerializedProperty _weaponNameProperty;
		private SerializedProperty _weaponDescriptionProperty;
		private SerializedProperty _damageProperty;
		private SerializedProperty _applyOverTimeProperty;
		private SerializedProperty _durationProperty;
		private SerializedProperty _damageTypeProperty;
		private SerializedProperty _isMagicalProperty;
		private SerializedProperty _manaUsageProperty;
		private SerializedProperty _staminaUsageProperty;
		private SerializedProperty _uiSpriteProperty;
		private SerializedProperty _displayNameProperty;
		private SerializedProperty _onHitSFXProperty;
		private SerializedProperty _onSlashSFXProperty;
		private SerializedProperty _onHitVFXProperty;
		private SerializedProperty _onSlashVFXProperty;

		private void OnEnable()
		{
			_weaponSpriteProperty = serializedObject.FindProperty("_sprite");
			_weaponNameProperty = serializedObject.FindProperty("_weaponName");
			_weaponDescriptionProperty = serializedObject.FindProperty("_description");
			_damageProperty = serializedObject.FindProperty("_damage");
			_applyOverTimeProperty = serializedObject.FindProperty("_applyOverTime");
			_durationProperty = serializedObject.FindProperty("_duration");
			_damageTypeProperty = serializedObject.FindProperty("_damageType");
			_isMagicalProperty = serializedObject.FindProperty("_isMagical");
			_manaUsageProperty = serializedObject.FindProperty("_manaUsage");
			_staminaUsageProperty = serializedObject.FindProperty("_staminaUsage");
			_uiSpriteProperty = serializedObject.FindProperty("_uiSprite");
			_displayNameProperty = serializedObject.FindProperty("_displayName");
			_onHitSFXProperty = serializedObject.FindProperty("_onHitSFX");
			_onSlashSFXProperty = serializedObject.FindProperty("_onSlashSFX");
			_onHitVFXProperty = serializedObject.FindProperty("_onHitVFX");
			_onSlashVFXProperty = serializedObject.FindProperty("_onSlashVFX");
		}

		public override void OnInspectorGUI()
		{
			EditorGUILayout.ObjectField(_weaponSpriteProperty);
		}
	}
}