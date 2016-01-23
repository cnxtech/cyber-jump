using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
  public Text winText;
  public GameObject[] cameras;
  public float terminateInv;

  private float currInv;
  private int index;

  void Start() {
    winText.text = "";
    currInv = terminateInv;
    index = 0;
  }

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

  public void Win() {
    winText.text = "Win!";
  }
}
