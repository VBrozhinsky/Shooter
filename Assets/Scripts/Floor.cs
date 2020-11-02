using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
    public Canvas canvas1;
    public Canvas canvas2;
    public string scene;
    void OnCollisionEnter(Collision myCollision)
    {
        if ((myCollision.gameObject.CompareTag("Target") || myCollision.gameObject.CompareTag("Target") ||
            myCollision.gameObject.CompareTag("Target")) && myCollision.gameObject.scene.name == scene)
        {
            canvas1.gameObject.SetActive(true);
            canvas2.gameObject.SetActive(false);
        }
    }
}
