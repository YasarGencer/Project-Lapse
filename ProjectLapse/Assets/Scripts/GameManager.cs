using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public Image cardOnDisplay;
    public Card currentCard;
    public TextMeshProUGUI text, Rtext, Ltext, DescriptionText;
    public static int cardCounter = 0;

    private StatStorage statStorage;
    public void SwipeEffect(bool value)
    {
        if (value)
            foreach (var statPair in currentCard.leftStats)
                statPair.stat.ApplyStats(statPair.changeValue);

        if (!value)
            foreach (var statPair in currentCard.rightStats)
                statPair.stat.ApplyStats(statPair.changeValue);

        cardCounter++;
        if (statStorage.CheckStats())
        {
            Debug.Log(statStorage.GetStat().name); // statStorage.GetStat().GetEndingCards ile oyun sonu kartlar� �ekilip ekrana getirilecek.
        }
        GetComponent<Stats_UI>().UpdateStats();
        GetComponent<SaveLoad>().Save();
        ChangeCard();
    }
    void ChangeCard()
    {
        Rtext.text = currentCard.Rtext;
        Ltext.text = currentCard.Ltext;
        text.text = currentCard.text;
        cardOnDisplay.sprite = currentCard.art;
        DescriptionText.text = currentCard.description;
    }
    private void Start()
    {
        statStorage = GetComponent<StatStorage>();
    }
}
