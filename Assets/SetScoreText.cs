using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetScoreText : MonoBehaviour
{
   public PlayerData playerData;
   private TMP_Text _scoreText;

   private void Awake()
   {
      _scoreText = GetComponent<TMP_Text>();
      _scoreText.text = playerData.score.ToString();
   }
}
