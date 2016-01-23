using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

  public GameObject particle;
  public DeviceController currentDevice;
	public AudioClip jumpFx;
	public GameController gameController;

  private bool hasFired;

  void Start() {
    hasFired = false;
  }

  void Update() {
    if (currentDevice != null) {
      transform.position = currentDevice.transform.position;
      transform.rotation = currentDevice.transform.rotation;
    }
  }

  void FixedUpdate() {
	if (gameController.isGameOver ()) {
		return;
	}

    if (!hasFired && Input.GetButtonDown("Fire1")) {
      FireRay();
      hasFired = true;
    }

    if (Input.GetButtonUp("Fire1")) {
      hasFired = false;
    }
  }

  void FireRay() {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit)) {
      GameObject collidedDevice = hit.collider.gameObject;

      if (collidedDevice.CompareTag("Device")) {

        Instantiate(particle, collidedDevice.transform.position, collidedDevice.transform.rotation);

        currentDevice = collidedDevice.GetComponent<DeviceController>();
        if (currentDevice.IsFunctioning()) {
          GetComponent<AudioSource>().PlayOneShot(jumpFx);
          currentDevice.CyberJump(this);
        }
      }
    }
  }

  public bool IsCurrentDevice(DeviceController otherController) {
    return currentDevice == otherController;
  }
}
