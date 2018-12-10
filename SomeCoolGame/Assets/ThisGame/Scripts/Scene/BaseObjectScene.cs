using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects
{


	public abstract class BaseObjectScene : MonoBehaviour
	{
		private int _layer;
		private Color _color;
		private Material _material;
		private Transform _myTransform;
		private Vector3 _position;
		private Quaternion _rotation;
		private Vector3 _scale;
		private GameObject _instanceObject;
		private Rigidbody _rigidbody;
		private string _name;
		private bool _isVisible;
		private bool _freeze;		
		#region Property
		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				InstanceObject.name = _name;
			}
		}
		public int Layers
		{
			get { return _layer; }
			set
			{
				_layer = value;
				if (InstanceObject != null)
				{
					InstanceObject.layer = _layer;
				}
				AskLayer(GetTransform, value);
			}
		}
		public Color Color
		{
			get { return _color; }
			set
			{
				_color = value;
				if (_material != null)
				{
					_material.color = _color;
				}
				AskColor(GetTransform, _color);
			}
		}
		public Material GetMaterial
		{
			get { return _material; }
		}
		public Vector3 Position
		{
			get
			{
				if (_instanceObject != null)
				{
					_position = GetTransform.position;
				}
				return _position;
			}
			set
			{
				_position = value;
				if (InstanceObject != null)
				{
					GetTransform.position = _position;
				}
			}
		}
		public Vector3 Scale
		{
			get
			{
				if (InstanceObject != null)
				{
					_scale = GetTransform.localScale;
				}
				return _scale;
			}
			set
			{
				_scale = value;
				if (InstanceObject != null)
				{
					GetTransform.localScale = _scale;
				}
			}
		}
		public Quaternion Rotation
		{
			get
			{
				if (InstanceObject != null)
				{
					_rotation = GetTransform.rotation;
				}
				return _rotation;
			}
			set
			{
				_rotation = value;
				if (_instanceObject != null)
				{
					GetTransform.rotation = _rotation;
				}
			}
		}
		public Rigidbody GetRigidbody
		{
			get { return _rigidbody; }
		}
		public GameObject InstanceObject
		{
			get { return _instanceObject; }
		}
		public bool IsVisible
		{
			get { return _isVisible; }
			set
			{
				_isVisible = value;
				if (InstanceObject.GetComponent<MeshRenderer>())
					InstanceObject.GetComponent<MeshRenderer>().enabled = _isVisible;
				if (InstanceObject.GetComponent<SkinnedMeshRenderer>())
					InstanceObject.GetComponent<SkinnedMeshRenderer>().enabled = _isVisible;
			}
		}
		public Transform GetTransform
		{
			get { return _myTransform; }
		}
		#endregion
		#region PrivateFunction
		public bool Freeze
		{
			get
			{
				return _freeze;
			}
		}
		private void AskLayer(Transform obj, int lvl)
		{
			obj.gameObject.layer = lvl;
			if (obj.childCount > 0)
			{
				foreach (Transform d in obj)
				{
					AskLayer(d, lvl);
				}
			}
		}
		private void AskColor(Transform obj, Color color)
		{
			obj.GetComponent<Renderer>().material.color = color;
			if(obj.childCount>0)
			{
				foreach(Transform d in obj)
				{
					AskColor(d, color);
				}
			}
		}
		#endregion
		#region UnityFunction
		protected virtual void Awake()
		{
			_instanceObject = gameObject;
			_name = _instanceObject.name;
			if (GetComponent<Renderer>())
			{
				_material = GetComponent<Renderer>().material;
			}
			_rigidbody = _instanceObject.GetComponent<Rigidbody>();
			_myTransform = _instanceObject.transform;
		}
		#endregion
		#region Protected Function

		public virtual void IsFreeze()
		{
			_freeze = true;
		}
		public virtual void IsNotFreeze()
		{
			_freeze = false;
		}
			#endregion
		}
}