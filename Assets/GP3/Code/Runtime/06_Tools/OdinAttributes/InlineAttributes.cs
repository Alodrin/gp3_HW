using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GP3._06_Tools.OdinAttributes
{
	public class InlineAttributes : MonoBehaviour
	{
		[Title("Inline Button")]
		[InlineButton("GetRandomValue", "Set Random")] [SerializeField] private float _value = 0.25f;

		[Title("Inline Properties")]
		[InlineProperty] [SerializeField] private MyClass _myInlineObject;
		[InlineProperty] [HideLabel] [SerializeField] private MyClass _myHideLabelInlineObject;
		[SerializeField] private MyClass _myNormalObject;
		
		[Title("Inline Editor")]
		[InlineEditor()] [SerializeField]
		private Animator _animator;
		
		private void GetRandomValue()
		{
			_value = Random.value;
		}

		[Serializable]
		public class MyClass
		{
			public float AFloat;
			public string AString;
			public int AnInt;
		}
	}
}