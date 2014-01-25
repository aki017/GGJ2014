using System.Collections.Generic;
using System;

public abstract class InputInterface{
	private List<Action> ups = new List<Action>();
	private List<Action> downs = new List<Action>();
	private List<Action> lefts = new List<Action>();
	private List<Action> rights = new List<Action>();
	private List<Action> bullets = new List<Action>();

	void Init(){
	}

	public void RegistorUp(Action action){
		ups.Add(action);
	}
	public void RegistorDown(Action action){
		downs.Add(action);
	}
    public void RegistorLeft(Action action){
		lefts.Add(action);
	}
	public void RegistorRight(Action action){
		rights.Add(action);
	}
	public void RegistorBullet(Action action){
		bullets.Add(action);
	}

	private void fireall(IList<Action> l){
		foreach(var a in l){
			a();
		}
	}

	public void FireUp(){ fireall (ups); }
	public void FireDown(){ fireall (downs); }
	public void FireLeft(){ fireall (lefts); }
	public void FireRight(){ fireall (rights); }
}
