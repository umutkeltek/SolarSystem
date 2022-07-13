using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UnderstandNameWhenClicked : MonoBehaviour
{      
    [SerializeField] public TextMeshProUGUI text;
      void Update()
       {
              //Check for mouse click 
              if (Input.GetMouseButtonDown(0))
              {
                  Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                  RaycastHit raycastHit;
                  Debug.DrawRay (Camera.main.transform.position, ray.direction * 0.1f);

                  if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity))
                  {
                      if (raycastHit.transform != null)
                      {
                         //Our custom method. 
                          CurrentClickedGameObject(raycastHit.transform.gameObject);
                      }
                  }
              }
       }
      
      public void CurrentClickedGameObject(GameObject gameObject)
      {
          if(gameObject.tag=="Celestial")
          {   text.text=gameObject.name;
              Debug.Log("You clicked on " + gameObject.name);
          }
          
      }
}
