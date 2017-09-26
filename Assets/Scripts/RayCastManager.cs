using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastManager : MonoBehaviour {

    private GameObject RayCastObj;

    [Header("RayCast Settings")]
    [SerializeField] private float RayCastlength=10;
    [SerializeField] private LayerMask Newlayermask;

    [Header("Refrences")]

    [SerializeField] private PlayerVitalUI playerVitles;
    [SerializeField] private Image CrossHair;
    [SerializeField] private Text ItemNameText;

    private void start()
    {
        
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position,fwd, out hit, RayCastlength, Newlayermask.value)){

            if (hit.collider.CompareTag("Consumable"))
            {
                CrossHairActive();
                RayCastObj = hit.collider.gameObject;

                if (Input.GetMouseButton(0))
                {
                    //When things are hit
                }
            }

        }
        else
        {
            CrossHairNormal();
        }

    }
    void CrossHairActive()
    {
        CrossHair.color = Color.red;
    }
    void CrossHairNormal()
    {
        CrossHair.color = Color.white;
    }






}
