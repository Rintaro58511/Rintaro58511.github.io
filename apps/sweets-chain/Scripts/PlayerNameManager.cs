using UnityEngine;
using System.Collections.Generic;
using PlayFab.ClientModels;
using PlayFab;
using TMPro;
public class PlayerNameManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;

    public void RegisterPlayerName()
    {
        string playerName = playerNameInput.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            var request = new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = playerName
            };

            PlayFabClientAPI.UpdateUserTitleDisplayName(request, result =>
            {
                Debug.Log("プレイヤー名の登録に成功: " + result.DisplayName);

                // プレイヤー名をPlayerPrefsに保存
                PlayerPrefs.SetString("PlayerName", playerName);
                PlayerPrefs.Save();

            }, error =>
            {
                Debug.LogError("プレイヤー名の登録に失敗: " + error.GenerateErrorReport());
            });
        }
        else
        {
            Debug.LogError("プレイヤー名が空です");
        }
    }

    // PlayerPrefsからプレイヤー名を取得
    public void LoadPlayerName()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerNameInput.text = PlayerPrefs.GetString("PlayerName");
        }
    }
}

