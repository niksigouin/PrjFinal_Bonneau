using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera targetCamera;
    // Start is called before the first frame update
    public OSC osc;

    // Update is called once per frame
    void Update()
    {
      OnClicked();   
    }
    
    void OnClicked()
    {
        OscMessage message;
        Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
 
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                if(Input.GetKeyDown("e"))
                {
                    message = new OscMessage();
                    message.address = "/item1";
                    message.values.Add(1);
                    osc.Send(message);
                    Debug.Log("PEW PEW DOWN");
                } else if (Input.GetKeyUp("e"))
                {
                    message = new OscMessage();
                    message.address = "/item1";
                    message.values.Add(0);
                    osc.Send(message);
                    Debug.Log("PEW PEW UP");
                }
                
            }
        }
    }
}
