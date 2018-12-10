using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Controllers
{
	public class InputController : BaseControllery
	{

		private bool _isActiveFlashlight = false;
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
			}
		}
	}
}