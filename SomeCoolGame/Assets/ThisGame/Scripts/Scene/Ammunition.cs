using UnityEngine;
using System.Collections;
namespace Game.Objects
{
	public abstract class Ammunition : MonoBehaviour
	{

		private GameObject _instanceObject;
		public GameObject InstanceObject
		{
			get { return _instanceObject; }
			set { _instanceObject = value; }
		}
		protected virtual void Awake()
		{

		}
	}
}