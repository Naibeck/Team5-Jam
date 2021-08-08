using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTilingEffect : MonoBehaviour
{
    public MeshRenderer renderer;
    public float rate;
    private void Update()
    {
        var offset = renderer.material.GetTextureOffset("_MainTex");
        renderer.material.SetTextureOffset("_MainTex", new Vector2(offset.x + (rate * Time.deltaTime),0));
    }
}
