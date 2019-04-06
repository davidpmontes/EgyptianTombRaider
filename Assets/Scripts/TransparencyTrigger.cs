using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparencyTrigger : MonoBehaviour
{
    public Tilemap backgroundTilemap;
    public Tilemap foregroundTilemap;

    private void Start()
    {
        ShowMap(backgroundTilemap);
        HideMap(foregroundTilemap);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HideMap(backgroundTilemap);
        ShowMap(foregroundTilemap);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ShowMap(backgroundTilemap);
        HideMap(foregroundTilemap);
    }

    private void ShowMap(Tilemap t)
    {
        Color color = t.color;
        color.a = 1;
        t.color = color;
    }

    private void HideMap(Tilemap t)
    {
        Color color = t.color;
        color.a = 0;
        t.color = color;
    }
}
