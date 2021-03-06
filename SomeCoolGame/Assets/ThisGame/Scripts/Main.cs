﻿using UnityEngine;
using System.Collections;
using Game.Controllers;
using Game.Objects;
using Game.Helpers;
namespace Game
{
	public sealed class Main : MonoBehaviour
	{

		private GameObject _controllersGameObject;
		private InputController _inputController;
		private FlashlightController _flashlightController;
		private FlashlightUIText _flText;
		private WeaponsController _weaponsController;
		private ObjectManager _objectManager;
		public enum MouseButton
		{
			LeftButton,
			RightButton,
			CenterButton
		}
		void Start()
		{
			Instance = this;
			_controllersGameObject = new GameObject { name = "Controllers" };
			_inputController =
				_controllersGameObject.AddComponent<InputController>();
			_flashlightController =
				_controllersGameObject.AddComponent<FlashlightController>();
			_flText = _controllersGameObject.AddComponent<FlashlightUIText>();
			_weaponsController =
				_controllersGameObject.AddComponent<WeaponsController>();
			_objectManager = GetComponent<ObjectManager>();
		}
		#region Property
		public FlashlightController GetFlashlightController
		{
			get { return _flashlightController; }
		}
		public InputController GetInputController()
		{
			return _inputController;
		}
		public static Main Instance { get; private set; }
		public ObjectManager GetManagerObject { get { return _objectManager; } }
		public WeaponsController GetWeaponsController { get { return _weaponsController; }  }
		#endregion
	}
}
