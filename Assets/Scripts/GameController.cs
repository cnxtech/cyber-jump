using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

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

      if (index < cameras.Length) {
        DeviceController nextDeviceController = NextDeviceController();
        if (player.IsCurrentDevice(nextDeviceController)) {
          progPercentage = (1 - currInv/terminateInv) * 100;
          progress.text = progPercentage.ToString("F2");
        }
      }
    } else {
      ShutdownCamera();
      currInv = terminateInv;
    }
		if (Input.GetKeyDown (KeyCode.R))
			restartlvl ();
  }

  void ShutdownCamera() {
    if (index < cameras.Length) {
      DeviceController deviceController = NextDeviceController();
      deviceController.Disable();
      index++;
    } else {
      // Gameover here
    }
  }

  DeviceController NextDeviceController() {
    return cameras[index].GetComponent<DeviceController>();
  }

  public void Win() {
    winText.text = "Win!";
  }

	public void restartlvl(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

}
