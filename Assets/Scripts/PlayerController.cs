using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

  public GameObject particle;

  private bool hasFired;

  void Start() {
    hasFired = false;
  }

  void FixedUpdate() {
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
      GameObject device = hit.collider.gameObject;

      if (device.CompareTag("Device")) {
        Instantiate(particle, device.transform.position, device.transform.rotation);

        DeviceController deviceController = device.GetComponent<DeviceController>();
        deviceController.CyberJump(this);
      }
    }
  }
}
