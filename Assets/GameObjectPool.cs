using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectPool : MonoBehaviour
{
	private static readonly Dictionary<string, GameObjectPool> _poolsByName = new Dictionary<string, GameObjectPool>();
	
	public static GameObjectPool GetPool(string name) { return _poolsByName[name]; }
	
	[SerializeField]
	private string _poolName = string.Empty;
	
	[SerializeField]
	private GameObject _prefab = null;
	
	[SerializeField]
	private int _initialCount = 10;
	
	[SerializeField]
	private bool _parentInstances = true;
	
	private readonly Stack<GameObject> _instances = new Stack<GameObject>();
	
	void Awake()
	{
		System.Diagnostics.Debug.Assert(_prefab);
		_poolsByName[_poolName] = this;
		
		for (int i = 0; i < _initialCount; i++)
		{
			var t = Instantiate(_prefab) as GameObject;
			InitializeInstance(t);
			ReleaseInstance(t);
		}
	}
	
	public GameObject GetInstance(Vector3 position = new Vector3())
	{
		GameObject t = null;
		
		if (_instances.Count > 0)
		{
			t = _instances.Pop();
		}
		else
		{
			Debug.LogWarning(_poolName + " pool ran out of instances!", this);
			t = Instantiate(_prefab) as GameObject;
		}
		
		t.transform.position = position;
		InitializeInstance(t);
		
		return t;
	}
	
	private void InitializeInstance(GameObject instance)
	{
		if (_parentInstances)
		{
			instance.transform.parent = transform;
		}
		
		instance.gameObject.SetActive(true);
		instance.BroadcastMessage("OnPoolCreate", this, SendMessageOptions.DontRequireReceiver);
	}
	
	public void ReleaseInstance(GameObject instance)
	{
		instance.BroadcastMessage("OnPoolRelease", this, SendMessageOptions.DontRequireReceiver);
		instance.gameObject.SetActive(false);
		_instances.Push(instance);
	}
}
