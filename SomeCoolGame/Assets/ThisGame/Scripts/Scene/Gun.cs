using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Objects
{
	public sealed class Gun : Weapons
	{		
		public override void Fire(Ammunition ammunition)
		{
			if(_fire)
			{
				if(ammunition)
				{
					Bullet tempbullet = Instantiate(ammunition, _gun.position, _gun.rotation) as Bullet;
					if(tempbullet)
					{
						tempbullet.GetRigidbody.AddForce(_gun.forward * _force);
						tempbullet.name="Bullet";
						_fire = false;
						_recharge.Start(_rechargeTime);
					}
				}
			}
		}
	}
}
