using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Controllers
{
	public class BaseControllery : MonoBehaviour
	{
		private bool _enabled;
		public bool Enabled
		{
			get
			{
				return _enabled;
			}
		}
		
		public virtual void On()
		{
			_enabled = true;
		}
		public virtual void Off()
		{
			_enabled = false;
		}
		}
}

