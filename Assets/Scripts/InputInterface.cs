using System.Collections.Generic;
using System;

public abstract class InputInterface{
	private List<Action<float>> ups = new List<Action<float>>();
	private List<Action<float>> downs = new List<Action<float>>();
	private List<Action<float>> lefts = new List<Action<float>>();
	private List<Action<float>> rights = new List<Action<float>>();
	private List<Action<float>> bullets = new List<Action<float>>();

	void Init(){
	}

	public void RegistorUp(Action<float> action){
		ups.Add(action);
	}
	public void RegistorDown(Action<float> action){
		downs.Add(action);
	}
	public void RegistorLeft(Action<float> action){
		lefts.Add(action);
	}
	public void RegistorRight(Action<float> action){
		rights.Add(action);
	}
	public void RegistorBullet(Action<float> action){
		bullets.Add(action);
	}

	private void fireall(IList<Action<float>> l, float v){
		foreach(var a in l){
			a(v);
		}
	}

	public void FireUp(float v = 1.0f){ fireall (ups,v); }
	public void FireDown(float v = 1.0f){ fireall (downs,v); }
	public void FireLeft(float v = 1.0f){ fireall (lefts,v); }
	public void FireRight(float v = 1.0f){ fireall (rights,v); }
	public void FireBullet(float v = 1.0f){ fireall (bullets,v); }
}
