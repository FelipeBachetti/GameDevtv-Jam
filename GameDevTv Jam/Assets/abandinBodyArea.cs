using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abandinBodyArea : MonoBehaviour
{
    public abandonBody script;

    private void OnTriggerEnter2D(Collider2D other) {
        script.canAbandon = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        script.canAbandon = false;
    }
}
