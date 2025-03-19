using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   public static UIManager Instance;
   [SerializeField] private Image dialog;
   [SerializeField] private Image HpBar;
    private PlayerControl player;
    private int questid;
    private void Awake()
    {
        Instance = this;
        player = GameObject.FindWithTag("Player").GetComponent
             <PlayerControl>();
        dialog.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        HpBar.fillAmount = (float)player.Health / player.MaxHealth;
    }
    public void Show(string name,string content,int id=-1)
    {
        Time.timeScale = 0;
    Cursor.lockState = CursorLockMode.None;
        dialog.gameObject.SetActive (true);
        dialog.transform.Find("NameText").GetComponent<TMP_Text>()
            .text=name;
        questid = id;
        if (QuestManager.Instance.HasQuest(id))
        {
            dialog.transform.Find("ContextText").GetComponent<TMP_Text>()
                    .text = "您已经接受该任务";
        }
        else
        {
            dialog.transform.Find("ContextText").GetComponent<TMP_Text>()
                        .text = content;
        }
        
    }
    public void AcceptButtonClick()
    {
        Time.timeScale = 1;
        dialog.gameObject.SetActive(false);
        QuestManager.Instance.AddQuest(questid);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void CancelButtonClick()
    {
        Time.timeScale = 1;
        dialog.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

    }
}
