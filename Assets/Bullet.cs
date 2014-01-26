using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public enum BulletType{
		BLACK,WHITE
	}

	public BulletType type = BulletType.BLACK;
	public GameObject HitEffect;
	private GameObjectPool _pool;

	// Update is called once per frame
	void Update () {
		if (!inStage() && renderer.enabled)
		{
			_pool.ReleaseInstance(gameObject);
		}
	}

	void Hit (bool flag) {
		Debug.Log (flag);
		_pool.ReleaseInstance(gameObject);
		GameObjectPool pool = GameObjectPool.GetPool(flag ? "DamageEffect" : "NoDamageEffect");
		pool.GetInstance(transform.position);
	}

	void Erase() {
		_pool.ReleaseInstance(gameObject);
	}

	

	void OnPoolCreate(GameObjectPool pool)
	{
		_pool = pool;

		renderer.enabled = true;
	}
	
	void OnPoolRelease()
	{
		renderer.enabled = false;
	}
	
	bool inStage()
	{
		var x = transform.position.x;
		var y = transform.position.y;
		return x > 0
			&& y > 0
				&& x < 102.4*3
				&& y < 76.8*3;
	}
}
