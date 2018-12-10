using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Helpers;
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
		protected Timer _recharge = new Timer();
		protected bool _fire = true;
		#endregion
		#region Abstract Function
		public abstract void Fire(Ammunition ammunition);
		#endregion
		protected virtual void Update()
		{
			_recharge.Update();
			if(_recharge.IsEvent())
			{
				_fire = true;
			}
		}
		private void Awake()
		{
			_gun = GetComponent<Transform>();
		}
	}
}
