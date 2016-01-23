using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class GameController : MonoBehaviour {
  public Text winText;
  public GameObject[] cameras;
  public float terminateDelay;
  public float terminateInv = 5.0f;
  public Text progress;
  public PlayerController player;
  public NoiseAndScratches effect;
  public float scratchMax = 2.0f;
  public float grainMax = 4.0f;

  private float currInv;
  private int index;
  private float progPercentage;

  void Start() {
    winText.text = "";
    currInv = terminateInv;
    index = 0;
  }

  void Update () {
    if (Time.time < terminateDelay) {
      return;
    } else {
      effect.enabled = true;
    }

    if (currInv > 0) {
      currInv -= Time.deltaTime;

      if (index < cameras.Length) {
        DeviceController nextDeviceController = NextDeviceController();
        if (player.IsCurrentDevice(nextDeviceController)) {
          progPercentage = (1-currInv/terminateInv);
          progress.text = progPercentage.ToString("F2");
          effect.grainIntensityMin = progPercentage*grainMax;
          effect.grainIntensityMax = effect.grainIntensityMin + 0.2f;
          effect.scratchIntensityMin = progPercentage*scratchMax;
          effect.scratchIntensityMax = effect.scratchIntensityMin + 0.2f;
        } else {
          effect.grainIntensityMin = 0;
          effect.grainIntensityMax = 0;
          effect.scratchIntensityMin = 0.05f;
          effect.scratchIntensityMax = 0.1f;
        }
      }
    } else {
      ShutdownCamera();
      currInv = terminateInv;
    }
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
}
