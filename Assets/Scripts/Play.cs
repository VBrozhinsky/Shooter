using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour {
    public Canvas canvas;
    public Canvas UI;

    public void OffPlay()
    {
        canvas.gameObject.SetActive(false);
        UI.gameObject.SetActive(true);
    }
}
