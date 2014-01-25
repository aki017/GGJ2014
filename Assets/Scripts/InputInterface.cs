using System.Collections.Generic;
using System;

public abstract class InputInterface{
	private List<Action<float>> ups = new List<Action<float>>();
	private List<Action<float>> downs = new List<Action<float>>();
	private List<Action<float>> lefts = new List<Action<float>>();
	private List<Action<float>> rights = new List<Action<float>>();
	private List<Action<float>> subups = new List<Action<float>>();
	private List<Action<float>> subdowns = new List<Action<float>>();
	private List<Action<float>> sublefts = new List<Action<float>>();
	private List<Action<float>> subrights = new List<Action<float>>();

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
	public void RegistorSubUp(Action<float> action){
		subups.Add(action);
	}
	public void RegistorSubDown(Action<float> action){
		subdowns.Add(action);
	}
	public void RegistorSubLeft(Action<float> action){
		sublefts.Add(action);
	}
	public void RegistorSubRight(Action<float> action){
		subrights.Add(action);
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
	public void FireSubUp(float v = 1.0f){ fireall (subups,v); }
	public void FireSubDown(float v = 1.0f){ fireall (subdowns,v); }
	public void FireSubLeft(float v = 1.0f){ fireall (sublefts,v); }
	public void FireSubRight(float v = 1.0f){ fireall (subrights,v); }
}
