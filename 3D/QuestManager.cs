using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;
    public static QuestManager Instance
    {
        get {
            if (instance == null)
            {
                GameObject go = new GameObject("QuestManager");
                instance = go.AddComponent<QuestManager>();
            }
            return instance;
        }
    }
    private List<QuestData> QuestList =new List<QuestData> ();
    public bool HasQuest(int id)
    {
        foreach (QuestData qd in QuestList)
        {
            if (qd.id == id)
            {
                return true;
            }
        }
        return false;
    }
    public void AddQuest(int id)
    {
        if (!HasQuest(id))
        {
            QuestList.Add(QuestDataManager.Instance.QuestDic[id]);
        }
    }
    public void AddEnemy(int enemyid)
    {
        for (int i = 0; i < QuestList.Count; i++)
        { 
        QuestData qd=QuestList[i];
            if (qd.enemyid == enemyid)
            {
                qd.currentCount++;
                if (qd.currentCount >= qd.count)
                {
                    Debug.Log("任务完成");
                    qd.currentCount = 0;
                    QuestList.Remove(qd);
                }
            }
        }
    }

}
