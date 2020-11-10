using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public TextMeshProUGUI gem_text;
    public TextMeshProUGUI bone_text;
    static int gem_score;
    int bone_score;
    public GameObject Harpoon;
    public GameObject HarpoonOOS;
    public GameObject CantAfford;


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

    public void HarpoonOutOfStock()
    {
        if (Harpoon != null)
        {
            Harpoon.SetActive(false);
            HarpoonOOS.SetActive(true);
        }
    }


    public void BuyHarpoon()
    {
        if (gem_score < 30)
        {
            StartCoroutine(ShortMessage(CantAfford, 1));
        }
        else
        {
            gem_score = gem_score - 30;
            gem_text.text = "Gems: " + gem_score.ToString();
            HarpoonOutOfStock();
        }
    }

    IEnumerator ShortMessage(GameObject go, int time)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(time);
        go.SetActive(false);
    }
}
