using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
  public Text winText;
  public GameObject[] cameras;
  public float terminateInv = 5.0f;
	public Text progress;
	public PlayerController player;

  private float currInv;
  private int index;
	private float progPercentage;

  void Start() {
    winText.text = "";
    currInv = terminateInv;
    index = 0;
  }

  void Update () {
    if (currInv > 0) {
      currInv -= Time.deltaTime;
		if (index < cameras.Length && (cameras[index].GetInstanceID() == player.currDevice.GetInstanceID())) {
			progPercentage = (1-currInv/terminateInv)*100;
			progress.text = progPercentage.ToString("F2");
		}


    } else {
      ShutdownCamera();
      currInv = terminateInv;
    }
  }

  void ShutdownCamera() {
    if (index < cameras.Length) {
	  DeviceController deviceController = cameras[index].GetComponent<DeviceController>();
		deviceController.Disable();
      
      index++;
    } else {
      // Gameover here
    }
  }

  public void Win() {
    winText.text = "Win!";
  }
}
