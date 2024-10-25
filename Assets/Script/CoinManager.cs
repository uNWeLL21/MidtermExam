using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coin;
    public Text CoinTXT;
    public bool Coins = true;
    public bool total = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(total){
            CoinTXT.text = $"Total Coins: {GameData.coin}";
            return;
        }
        if(Coins)
            CoinTXT.text = $"Coin: {coin}";
        else
            CoinTXT.text = $"Score: {50 + (GameData.score * 5)}";
    }
}
