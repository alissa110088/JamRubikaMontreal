using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D defaultCursor; // Assign in Inspector
    public Texture2D clickableCursor; // Assign in Inspector
    public Vector2 hotspot = Vector2.zero; // Hotspot for the cursor

    // Called when the mouse enters the GameObject's collider
    void OnMouseEnter()
    {
        Cursor.SetCursor(clickableCursor, hotspot, CursorMode.Auto);
    }

    // Called when the mouse exits the GameObject's collider
    void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
    }
}