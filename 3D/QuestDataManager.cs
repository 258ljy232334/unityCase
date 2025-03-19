using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

using System;
using Unity.VisualScripting;

public class QuestDataManager : MonoBehaviour
{
    private static QuestDataManager instance;
    private static readonly object lockObject = new object();

    public static QuestDataManager Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        GameObject go = new GameObject("QuestManager");
                        instance = go.AddComponent<QuestDataManager>();
                    }
                }
            }
            return instance;
        }
    }

    public Dictionary<int, QuestData> QuestDic = new Dictionary<int, QuestData>();

    private QuestDataManager()
    {
        XmlDocument doc = new XmlDocument();
        try
        {
            doc.Load(Application.dataPath + "/XML/quest.xml");
            XmlElement rootEle = doc.DocumentElement;
            if (rootEle != null)
            {
                foreach (XmlNode questNode in rootEle.ChildNodes)
                {
                    if (questNode is XmlElement questEle)
                    {
                        QuestData data = new QuestData();
                        data.id = int.Parse(questEle.GetElementsByTagName("id")[0].InnerText);
                        data.name = questEle.GetElementsByTagName("name")[0].InnerText;
                        data.enemyid = int.Parse(questEle.GetElementsByTagName("enemyid")[0].InnerText);
                        data.count = int.Parse(questEle.GetElementsByTagName("count")[0].InnerText);
                        data.currentCount = 0; // ³õÊ¼»¯Îª0
                        data.money = int.Parse(questEle.GetElementsByTagName("money")[0].InnerText);
                        QuestDic.Add(data.id, data);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error loading quest data: " + ex.Message);
        }
    }
}

public class QuestData
{
    public int id { get; set; }
    public string name { get; set; }
    public int enemyid { get; set; }
    public int count { get; set; }
    public int currentCount { get; set; }
    public int money { get; set; }
}
