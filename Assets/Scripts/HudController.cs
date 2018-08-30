using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour {

    private Text _playerNameText;
    private Text _walletAmountText;
    private Text _nestorStockText;
    private Text _sparkStockText;
    private Text _etchStockText;
    private Text _roveStockText;
    private Text _fleetStockText;
    private Text _echoStockText;
    private Text _boltStockText;

    private void Awake() {
        _playerNameText = GameObject.Find("PlayerName").GetComponent<Text>();
    	_walletAmountText = GameObject.Find("PlayerWalletAmount").GetComponent<Text>();
    	_nestorStockText = GameObject.Find("PlayerStockNestor").GetComponent<Text>();
    	_sparkStockText = GameObject.Find("PlayerStockSpark").GetComponent<Text>();
    	_etchStockText = GameObject.Find("PlayerStockEtch").GetComponent<Text>();
    	_roveStockText = GameObject.Find("PlayerStockRove").GetComponent<Text>();
    	_fleetStockText = GameObject.Find("PlayerStockFleet").GetComponent<Text>();
    	_echoStockText = GameObject.Find("PlayerStockEcho").GetComponent<Text>();
    	_boltStockText = GameObject.Find("PlayerStockBolt").GetComponent<Text>();
}

    public void SetPlayerName (string newName) {
        _playerNameText.text = newName;
    }

    public void SetWalletAmount(int newAmount) {
        _walletAmountText.text = newAmount.ToString();
    }

    public void UpdatePlayerStock(List<Stock> stocks) {
        _nestorStockText.text = "NESTOR: " + stocks.FindAll(stock => stock.CorporationId.Equals(0)).Count.ToString();
        _sparkStockText.text = "SPARK: " + stocks.FindAll(stock => stock.CorporationId.Equals(1)).Count.ToString();
        _etchStockText.text = "ETCH: " + stocks.FindAll(stock => stock.CorporationId.Equals(2)).Count.ToString();
        _roveStockText.text = "ROVE: " + stocks.FindAll(stock => stock.CorporationId.Equals(3)).Count.ToString();
        _fleetStockText.text = "FLEET: " + stocks.FindAll(stock => stock.CorporationId.Equals(4)).Count.ToString();
        _echoStockText.text = "ECHO: " + stocks.FindAll(stock => stock.CorporationId.Equals(5)).Count.ToString();
        _boltStockText.text = "BOLT: " + stocks.FindAll(stock => stock.CorporationId.Equals(6)).Count.ToString();
    }

}