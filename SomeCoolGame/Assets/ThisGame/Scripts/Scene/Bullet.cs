using UnityEngine;
using System.Collections;
using Game.Interfaces;
namespace Game.Objects
{


	public class Bullet : Ammunition
	{
		[SerializeField] private float _timeToDestruct = 10;
		[SerializeField] private float _damage = 20;
		[SerializeField] private float _mass = 0.01f;
		private Rigidbody _rigidbody;
		public Rigidbody GetRigidbody
		{
			get { return  _rigidbody; } 
		}
		private float _currentDamage;
		protected override void Awake()
		{
			base.Awake();
			_rigidbody = GetComponent<Rigidbody>();
			Destroy(InstanceObject, _timeToDestruct);
			_currentDamage = _damage;
			GetRigidbody.mass = _mass;
		}
		private void OnCollisionEnter(Collision collision)
		{
			if (collision.collider.tag == "Bullet") return;
			SetDamage(collision.gameObject.GetComponent<ISetDamage>());
			Destroy(InstanceObject);
		}
		private void SetDamage(ISetDamage obj)
		{
			if (obj != null)
				obj.ApplyDamage(_currentDamage);
		}
	}
}