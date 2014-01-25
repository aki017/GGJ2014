using System.Collections.Generic;
using System;

public abstract class InputInterface{
	public enum Type{
		UP,DOWN,LEFT,RIGHT,
		SUBUP,SUBDOWN,SUBLEFT,SUBRIGHT,
	}
	private Dictionary<Type, Action<float>> actions = new Dictionary<Type, Action<float>>();

	void Init(){
	}

	public Action<Action<float>> Registor(Type t) {
		return (f)=> Registor (t, f);
	}
	public void Registor(Type t, Action<float> a) {
		if (!actions.ContainsKey(t)){
			actions[t] = a;
		}else{
			actions[t] += a;
		}
	}

	public Action<float> Fire(Type type) {
		return (f)=> Fire (type, f);
	}
	public void Fire(Type type, float v){
		if(actions.ContainsKey(type)) {
			actions[type](v);
		}
	}
}
