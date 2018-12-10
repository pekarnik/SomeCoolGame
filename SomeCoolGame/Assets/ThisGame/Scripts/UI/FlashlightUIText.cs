using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashlightUIText : MonoBehaviour
{
	private Text _text;
	private void Start()
	{
		_text = GetComponent<Text>(); ;
	}
	public float Text
	{
		set { _text.text = $"{value:0.0}"; }
	}
	private void SetActive(bool value)
	{
		_text.gameObject.SetActive(value);
	}
}
