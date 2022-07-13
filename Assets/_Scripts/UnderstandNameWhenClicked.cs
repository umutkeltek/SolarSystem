using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UnderstandNameWhenClicked : MonoBehaviour
{      
    [SerializeField] public TextMeshProUGUI text;
    [SerializeField] private GameObject Panel;
    private bool active;
      void Update()
       {
              //Check for mouse click 
              if (Input.GetMouseButtonDown(0))
              {
                  Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                  RaycastHit raycastHit;
                  Debug.DrawRay (Camera.main.transform.position, ray.direction * 0.1f);
                  //Check if the raycast hit the planet so we can display the name
                  if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity))
                  {
                      if (raycastHit.transform != null) //If the raycast git something
                      {
                         
                          CurrentClickedGameObject(raycastHit.transform.gameObject); //Display the name of the planet
                      }
                  }
              }
       }
      
      public void CurrentClickedGameObject(GameObject gameObject) //check the raycast hit object has a tag of "celestial" and change the ui 
      {
          if(gameObject.tag=="Celestial")
          {
              if (Panel != null)
              {
                  Panel.SetActive(true);
              }
              text.text=gameObject.name;
              //Debug.Log("You clicked on " + gameObject.name);
          }
          
      }

      public void ClosePanel() // close panel method for the button
      {
          Panel.SetActive(false);
      }
}
