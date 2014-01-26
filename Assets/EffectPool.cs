using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class EffectPool : MonoBehaviour
{
	private GameObjectPool _pool;

	void Awake() {
		gameObject.renderer.sortingLayerName = "ForeGround";
		gameObject.renderer.sortingOrder = 2;
	}
	
	void OnPoolCreate(GameObjectPool pool)
	{
		_pool = pool;
		
		particleSystem.renderer.enabled = true;
		particleSystem.time = 0;
		particleSystem.Clear(true);
		particleSystem.Play(true);
	}
	
	void OnPoolRelease()
	{
		particleSystem.Stop();
		particleSystem.time = 0;
		particleSystem.Clear(true);
		particleSystem.renderer.enabled = false;
	}
	
	void Update()
	{
		if (!particleSystem.IsAlive(true) && particleSystem.renderer.enabled)
		{
			_pool.ReleaseInstance(gameObject);
		}
	}
}