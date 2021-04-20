using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abilityUI : MonoBehaviour
{
    public UnityEngine.UI.Text ability;

    // Start is called before the first frame update
    void Start()
    {
        updateLabel();
    }

    // Update is called once per frame
    void Update()
    {
        updateLabel();
    }

    public void updateLabel() {
        if (Kernen_script.bought_ability_reverse && Kernen_script.selected_ability_reverse) {
            ability.text = Kernen_script.available_ability_reverse.ToString();
        }
    }
}
