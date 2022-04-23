using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinShopItem : MonoBehaviour
{

    [SerializeField] private SkinManager skinManager;
    [SerializeField] private int skinIndex;
    [SerializeField] private Button buyButton;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private TMP_Text purchaseText;
    [SerializeField] private TMP_Text insufficientText;
    private Skin skin;

    // Start is called before the first frame update
    void Start()
    {
        skin = skinManager.skins[skinIndex];

        GetComponent<Image>().sprite = skin.sprite;

        if(skinManager.IsUnlocked(skinIndex))
        {
            buyButton.gameObject.SetActive(false);
            purchaseText.gameObject.SetActive(true);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            costText.text = skin.cost.ToString() + " Coins"; 
        }    

    }

    public void OnSkinPressed()
    {
        if(skinManager.IsUnlocked(skinIndex))
        {
            skinManager.SelectSkin(skinIndex);
        }
    }

    public void OnBuyButtonPressed()
    {
        int coins = PlayerPrefs.GetInt("Coins");

        if (coins >= skin.cost && !skinManager.IsUnlocked(skinIndex))
        {
            PlayerPrefs.SetInt("Coins", coins - skin.cost);
            skinManager.Unlock(skinIndex);
            buyButton.gameObject.SetActive(false);
            purchaseText.gameObject.SetActive(true);
            skinManager.SelectSkin(skinIndex);
        }
        else
        {
            //Debug.Log("Not Enough Coins :(");
            StartCoroutine(InsufficientCoins());
        }
    }

    IEnumerator InsufficientCoins()
    {
        insufficientText.gameObject.SetActive(true);
        buyButton.gameObject.SetActive(false);

        yield return new WaitForSecondsRealtime(2f);

        insufficientText.gameObject.SetActive(false);
        buyButton.gameObject.SetActive(true);

    }

}
