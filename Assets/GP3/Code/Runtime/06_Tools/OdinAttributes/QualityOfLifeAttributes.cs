using Sirenix.OdinInspector;
using UnityEngine;

namespace GP3._06_Tools.OdinAttributes
{
	public class QualityOfLifeAttributes : MonoBehaviour
	{
		[PreviewField(ObjectFieldAlignment.Center, Height = 100)] [SerializeField] private Texture _texture;
		[SuffixLabel("%")] [SerializeField] [OnValueChanged("OnDamagePercentValueChanged")]
		private float _damagePercent;

		[ProgressBar(0, 100)] [SerializeField] 
		private float _xpProgress;
		[LabelText("@_stringToLabelText")] [SerializeField]
		private string _stringToLabelText;
		[HideLabel] [SerializeField] private int _numberWithoutLabel;

		[FilePath(ParentFolder = "Assets/UEGP3", Extensions = ".prefab")] [SerializeField] private string _myFilePath;
		[FolderPath] [SerializeField] private string _myFolderPath;

		[OnValueChanged("OnPrefabReferenceChanged")] [SerializeField] [InfoBox("Cant use this prefab at runtime as it has no rigidbody.", InfoMessageType.Error, "@_rigidbody == null")]
		private GameObject _prefab;
		[SerializeField] [ReadOnly] private Rigidbody _rigidbody;
		
		private void OnPrefabReferenceChanged()
		{
			Debug.Log("Exchanging Prefab Reference");
			_rigidbody = _prefab.GetComponent<Rigidbody>();
		}
		
		private void OnDamagePercentValueChanged()
		{
			Debug.Log($"Damage Percent now is {_damagePercent}");
		}

		[Button]
		private void PrintRandomNumberToConsole()
		{
			Debug.Log($"The random number is {Random.value * 100}");
		}
	}
}