using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

  public Text winText;

  void Start() {
    winText.text = "";
  }

  public void Win() {
    winText.text = "Win!";
  }
}
