using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopController : MonoBehaviour
{
    //[SerializeField] private Image selectedSkin;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private SkinManager skinManager;

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "Coins: " + PlayerPrefs.GetInt("Coins");
        //selectedSkin.sprite = skinManager.GetSelectedSkin().sprite;
    }

    //public void LoadGame() => SceneManager.LoadScene("GameScene");

}
