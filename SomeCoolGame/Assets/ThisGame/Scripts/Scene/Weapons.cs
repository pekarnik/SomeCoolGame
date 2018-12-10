using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Objects
{
	public abstract class Weapons : BaseObjectScene
	{
		#region Serialize Variable
		[SerializeField] protected Transform _gun;
		[SerializeField] protected float _force = 500;
		[SerializeField] protected float _rechargeTime = 0.2f;
		#endregion
		#region Protected Variable
		protected bool _fire = true;
		#endregion
		#region Abstract Function
		public abstract void Fire();
		#endregion
	}
}
