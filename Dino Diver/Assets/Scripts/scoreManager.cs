using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{

    public static scoreManager instance;
    public TextMeshProUGUI gem_text;
    public TextMeshProUGUI bone_text;
    int gem_score;
    int bone_score;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeGem(int gemValue)
    {
        gem_score += gemValue;
        gem_text.text = "Gems: " + gem_score.ToString();
    }

    public void ChangeBone(int boneValue)
    {
        bone_score += boneValue;
        bone_text.text = "Bones: " + bone_score.ToString();
    }
}
