using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HomeController : MonoBehaviour
{
    public DialougeManager diaMan;
    private bool dialogueMode=false;
    // Start is called before the first frame update
    void Start()
    {
        dialogueMode=true;
        diaMan.startDemo();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueMode){
            if(Input.GetMouseButtonDown(0)){
            PointerEventData pointerData = new PointerEventData(EventSystem.current);

            pointerData.position = Input.mousePosition; // use the position from controller as start of raycast instead of mousePosition.

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            if (results.Count > 1) {
                //WorldUI is my layer name
                string dbg = "Root Element: {0} \n GrandChild Element: {1}";
                Debug.Log(string.Format(dbg, results[results.Count-1].gameObject.name,results[0].gameObject.name));
                Debug.Log(results[1].gameObject.name);
                if(results.Count>=2){
                    if(results[1].gameObject.name=="Button"){

                    }else{
                        diaMan.nextMessage();
                    }
                }
                results.Clear();
                
                
     
            }
        }
        }
        
        
    }
}
