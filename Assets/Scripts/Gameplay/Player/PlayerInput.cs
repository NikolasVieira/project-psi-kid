using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public float GetHorizontalInput() {
        return Input.GetAxis("Horizontal");
    }

    public bool IsJumpPressed() {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
