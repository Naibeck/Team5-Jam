using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public List<LevelModule> modules;
    public LevelModule finalModule;
    public int maxModules;
    public Transform currentEnd;
    public LevelMove levelMove;


    private void Start()
    {
        CreateLevel();
    }

    private void CreateLevel()
    {
        for (int i = 0; i < maxModules; i++)
        {
            int ran = modules.Count > 0 ? Random.Range(0, modules.Count) : 0;

            if (i == 0)
                SpawnModule(modules[ran]);
            if (i == maxModules - 1)
                SpawnModule(finalModule, currentEnd);
            else
                SpawnModule(modules[ran], currentEnd);
        }
    }

    void SpawnModule(LevelModule o,Transform t = null)
    {
        GameObject newObject;
        if (t != null)
            newObject = Instantiate(o.gameObject, t.position, o.transform.rotation, t);
        else
        {
            newObject = Instantiate(o.gameObject);
            levelMove.level = newObject.transform;
        }

        if (o == finalModule)
            levelMove.levelEnd = newObject.GetComponent<LevelModule>().levelEnd;

        currentEnd = newObject.GetComponent<LevelModule>().end;
    }
}
