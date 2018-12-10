using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Controllers
{
	public class InputController : BaseControllery
	{

		private bool _isActiveFlashlight = false;
		private bool _isSelectWeapons = true;
		private int _indexWeapons=0;
		public void Update()
		{
			{
				if(Input.GetKeyDown(KeyCode.F))
				{
					_isActiveFlashlight = !_isActiveFlashlight;
					if(_isActiveFlashlight)
					{
						Main.Instance.GetFlashlightController.On();
					}
					else
					{
						Main.Instance.GetFlashlightController.Off();
					}
				}
				if(Input.GetKeyDown(KeyCode.Alpha1))
				{
					_indexWeapons = 0;
					_isSelectWeapons = false;
				}
				if(Input.GetKeyDown(KeyCode.Alpha2))
				{
					_indexWeapons = 1;
					_isSelectWeapons = false;
				}
				if (_isSelectWeapons) return;
				if(Main.Instance.GetManagerObject.GetWeaponsList[_indexWeapons])
				{
					Main.Instance.GetWeaponsController.On(Main.Instance.GetManagerObject.GetWeaponsList[_indexWeapons],
						Main.Instance.GetManagerObject.GetAmmunitionList[_indexWeapons]);
				}
				_isSelectWeapons = true;
			}
		}
	}
}