using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Transform playerHead;
    public float rayLenght = 10;

    public Weapon weapon;

    private float shootTimer = 0.0f;
    private WaitForSeconds lineRendererVisibilityTime;

    private ImageProgressBar imgProgressBar;

    void Start()
    {
        weapon.Init();
        lineRendererVisibilityTime = new WaitForSeconds(weapon.fireRate * 0.5f);
    }

    void Update()
    {
        Raycast();
        shootTimer += Time.deltaTime;
    }

    private void Raycast()
    {
        Ray ray = new Ray(playerHead.position, playerHead.forward);
        RaycastHit hit;

        Debug.DrawRay(playerHead.position, playerHead.forward * rayLenght, Color.green, 0.1f);

        if(Physics.Raycast (ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Target") && shootTimer >= weapon.fireRate)
            {
                MakeTargetShot(hit.collider.gameObject, hit);
                return;
            }
            if (hit.collider.gameObject.CompareTag("WalkingTarget") && shootTimer >= weapon.fireRate)
            {
                MakeWalkingTargetShot(hit.collider.gameObject, hit);
                return;
            }
            if (hit.collider.gameObject.CompareTag("VR_UI"))
            {
                imgProgressBar = hit.collider.gameObject.GetComponent<ImageProgressBar>();
                imgProgressBar.GazeOver = true;
                imgProgressBar.StartFillingProgressBar();
                return;
            } else if(imgProgressBar != null)
            {
                imgProgressBar.GazeOver = false;
                imgProgressBar.StopFillingProgressBar();
                imgProgressBar = null;
                return;
            }
        }
    }

    private void MakeTargetShot(GameObject targetRb, RaycastHit hit)
    {
        weapon.ShootTarget(hit.point, -hit.normal, targetRb);
        shootTimer = 0.0f;
        StartCoroutine(HandleLineRenderer());
    }

    private void MakeWalkingTargetShot(GameObject targetGo, RaycastHit hit)
    {
        weapon.ShootWalkingTarget(hit.point, - hit.normal, targetGo);
        shootTimer = 0.0f;
        StartCoroutine(HandleLineRenderer());
    }

    private IEnumerator HandleLineRenderer()
    {
        yield return lineRendererVisibilityTime;
        weapon.ClearShootTrace();
    }
}
