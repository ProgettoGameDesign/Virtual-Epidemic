using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsantiColori : MonoBehaviour
{
    public string buttonValue;
    [SerializeField] private TastierinoServetti keypadManager;
    //[SerializeField] private ChangeColorDisplay changeColorDisplay;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        if (keypadManager != null)
        {
            //Debug.Log("hai premuto 1");
            keypadManager.AddDigit(buttonValue);
            keypadManager.IlluminaDisplay(buttonValue);
            animator.SetBool("premuto", true);
        }
    }
}
