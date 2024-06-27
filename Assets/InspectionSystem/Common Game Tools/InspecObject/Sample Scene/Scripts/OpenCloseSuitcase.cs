using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseSuitcase : MonoBehaviour {

    bool opened = false;
    bool clickStarted = false;


	public void OpenSuitCase()
    {
        if (opened)
            return;
        gameObject.GetComponent<Animator>().Play("OpenSuitcase", -1, 0f);
        opened = true;
    }

    public void CloseSuitCase()
    {
        if (!opened)
            return;
        gameObject.GetComponent<Animator>().Play("CloseSuicase", -1, 0f);
        opened = false;
    }


    void Update()
    {
        Ray ray = CGT.InspectManager.instance.inspectCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.name == "Locker")
                    clickStarted = true;
            }
            else
                clickStarted = false;
        }

        if (Input.GetMouseButtonUp(0)) {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Locker" && clickStarted)
                {
                    if (opened)
                        CloseSuitCase();
                    else
                        OpenSuitCase();
                }
            }
            else
                clickStarted = false;
        }
    }


}
