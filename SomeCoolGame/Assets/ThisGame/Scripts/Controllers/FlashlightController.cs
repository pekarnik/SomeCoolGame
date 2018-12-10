using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Controllers
{
	public sealed class FlashlightController : BaseControllery
	{
		private Light _light;
		private float _charge;
		private FlashlightUIText _uiText;
		public float ChargeMax
		{
			get;set;
		}
		public float Charge
		{
			get { 
				return _charge; }
			set { _charge = value; }
		}
		private void Awake()
		{
			_light = GameObject.Find("Flashlight").GetComponent<Light>();
			_uiText = GameObject.Find("FLtext").GetComponent<FlashlightUIText>();
			ChargeMax = 10;
			Charge = ChargeMax;
		}
		public void Start()
		{
			SetActiveFlashlight(false);
			_charge = ChargeMax;
		}
		public void Update()
		{
			if (!Enabled&&Charge==ChargeMax)
				return;
			ChargeChanged();
		}
		private void SetActiveFlashlight(bool value)
		{
			_light.enabled = value;
		}
		public override void On()
		{
			if (Enabled) return;
			base.On();
			SetActiveFlashlight(true);
		}
		public override void Off()
		{
			if (!Enabled) return;
			base.Off();
			{
				SetActiveFlashlight(false);
			}
		}
		private void ChargeChanged()
		{
			if(Enabled&&Charge>0)
			{
				_charge -= Time.deltaTime;
			}
			else
			{
				if(Charge<ChargeMax)
				{
					_charge += Time.deltaTime;
				}
			}
			if(Charge<=0)
			{
				Off();
			}
			_uiText.Text = Charge;
		}
	}
}
