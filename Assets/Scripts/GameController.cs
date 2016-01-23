using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject[] cameras;
	public float terminateInv;
	private float currInv;
	private int index;

	// Use this for initialization
	void Start () {
		terminateInv = 5.0f;
		currInv = terminateInv;
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (currInv > 0) {
			currInv -= Time.deltaTime;
		} else {
			ShutdownCamera();
			currInv = terminateInv;
		}
	}

	void ShutdownCamera() {
		if (index < cameras.Length) {
			MeshRenderer rend = cameras[index].GetComponent<MeshRenderer> ();
			rend.material.SetColor ("_Color", Color.red);
			index++;
		} else {
			// Gameover here
		}
	}
}
