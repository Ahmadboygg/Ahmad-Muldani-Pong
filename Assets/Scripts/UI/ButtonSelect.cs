using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    public List<Button>buttons;
    private int i;
    private int currentSelectedButton;
    
    void Update()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if(i == currentSelectedButton)
            {
                buttons[currentSelectedButton].Select();
            }
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentSelectedButton < buttons.Count -1)
            {
                currentSelectedButton++;
            }
            else if(currentSelectedButton >= buttons.Count -1)
            {
                currentSelectedButton = 0;
            }
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentSelectedButton > 0)
            {
                currentSelectedButton--;
            }
            else if(currentSelectedButton <= 0 )
            {
                currentSelectedButton = buttons.Count -1;
            }
        }
    }
}
