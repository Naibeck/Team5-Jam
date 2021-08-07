using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{

    public List<LevelModule> modules;
    public int maxModules;
    public Transform currentEnd;

    private void Start()
    {
        for(int i = 0; i < maxModules; i++)
        {
            int ran = modules.Count > 0 ? Random.Range(0, modules.Count) : 0;
            if (i == 0)
            {
                SpawnModule(modules[ran]);
            }
            else
            {
                SpawnModule(modules[ran], currentEnd);
            }
        }
    }

    void SpawnModule(LevelModule o,Transform t = null)
    {
        if(t != null)
        {
            var newObject = Instantiate(o.gameObject, t.position, o.transform.rotation);
            currentEnd = newObject.GetComponent<LevelModule>().end;
        }
        else
        {
            var newObject = Instantiate(o.gameObject);
            currentEnd = newObject.GetComponent<LevelModule>().end;
        }
    }
}
