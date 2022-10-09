using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SgLib;

public class AddScore : MonoBehaviour {
	
	public int ScoreToAdd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void addScore(){
		ScoreManager.Instance.AddScore(ScoreToAdd);
	}
	
	public void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player")
		addScore();
	}
}
