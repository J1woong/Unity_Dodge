using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager: MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject MainMenuButtons;

    [Header("Sub Menus")]
    public GameObject DifficultyMenu;
    public GameObject Characters;

    public Material playerColorMaterial;

    public void OpenGameStart()
    {
        CloseAllSubMenus();
        DifficultyMenu.SetActive(true);
    }

    public void OpenCharacters()
    {
        CloseAllSubMenus();
        Characters.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }

    private void CloseAllSubMenus()
    {
        DifficultyMenu.SetActive(false);
        Characters.SetActive(false);
        MainMenuButtons.SetActive(false);
    }

    public void LoadEasyScene()
    {
        SceneManager.LoadScene("EasyMode");
    }

    public void LoadNormalScene()
    {
        SceneManager.LoadScene("NormalMode");
    }

    public void LoadHardScene()
    {
        SceneManager.LoadScene("HardMode");
    }

    public void SelectCharacter(string characterName)
    {

        switch (characterName)
        {
            case "P1":
                playerColorMaterial.color = new Color32(0xF8, 0xF5, 0x48, 0xFF); // 노란색
                break;
            case "P2":
                playerColorMaterial.color = new Color32(0x32, 0xBB, 0xFF, 0xFF); // 파란색
                break;
            case "P3":
                playerColorMaterial.color = new Color32(0x91, 0xEF, 0x3C, 0xFF); // 녹색
                break;
            case "P4":
                playerColorMaterial.color = new Color32(0xFF, 0xFF, 0xFF, 0xFF); // 흰색
                break;
        }

        // 선택 후 메인 메뉴로 돌아가기
        Characters.SetActive(false);
        MainMenuButtons.SetActive(true);
    }
    public void BackToMainMenu()
    {
        // 서브 메뉴를 모두 닫고, 메인 메뉴 버튼을 다시 보여줌
        CloseAllSubMenus();
        MainMenuButtons.SetActive(true);
    }
}
