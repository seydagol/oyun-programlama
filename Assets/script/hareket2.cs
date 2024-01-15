using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket2 : MonoBehaviour
{
    Camera kamera;
    GameObject[] g�lgeler;
    Vector2 baslang�c_posizyon;
    son son_script;

    void Start()
    {
        kamera = GameObject.Find("camera").GetComponent<Camera>();
        g�lgeler = GameObject.FindGameObjectsWithTag("g�lge");
        baslang�c_posizyon = transform.position;
        son_script = GameObject.Find("son").GetComponent<son>();

    }



    private void OnMouseDrag()
    {
        Vector3 pozisyon = kamera.ScreenToWorldPoint(Input.mousePosition);
        pozisyon.z = 0;
        transform.position = pozisyon;
    }




    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            foreach (GameObject g�lge in g�lgeler)
            {
                if (gameObject.name == g�lge.name)
                {
                    float mesafe = Vector3.Distance(g�lge.transform.position, transform.position);
                    if (mesafe <= 1)
                    {
                        transform.position = g�lge.transform.position;
                        Destroy(this);
                        son_script.level_son();
                    }
                    else
                    {
                        transform.position = baslang�c_posizyon;
                    }
                }
            }
        }
    }



}
