using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NodeEditor : EditorWindow {
    public Texture2D background;
    Vector2 viewOffset;
    Vector2 canvasSize;
    Vector2 canvasPosition = new Vector2(180.0f, 0.0f);

    [MenuItem("Window/Node Editor")]
    public static void ShowWindow() {
        GetWindow<NodeEditor>().Show();
        GetWindow<NodeEditor>().titleContent = new GUIContent("Node Editor");
    }

    void DrawCanvas() {
        GUI.DrawTextureWithTexCoords(
            new Rect(canvasPosition.x, canvasPosition.y + canvasSize.y, canvasSize.x, -canvasSize.y),
            background,
            new Rect(viewOffset.x, viewOffset.y, (canvasSize.x / (background.width)), (canvasSize.y / (background.height))));
    }

    void HandleMouseEvents() {    
        if (Event.current.type == EventType.MouseDrag && Event.current.button == 2) {
            if (new Rect(canvasPosition, canvasSize).Contains(Event.current.mousePosition)) {
                float sensitivity = 0.005f;

                viewOffset.x -= Event.current.delta.x * sensitivity;
                viewOffset.y -= Event.current.delta.y * sensitivity;

                if (viewOffset.x < 0.0f)
                    viewOffset.x = 0.0f;
                if (viewOffset.y < 0.0f)
                    viewOffset.y = 0.0f;

                Repaint();
            }
        }
    }

    void UpdateCanvasSize() {
        canvasSize.x = position.size.x - canvasPosition.x;
        canvasSize.y = position.size.y;
    }

    void OnGUI() {
        UpdateCanvasSize();
        HandleMouseEvents();
        DrawCanvas();
        
        GUI.Label(new Rect(5.0f, 5.0f, 200.0f, 25.0f), "MMB - Move canvas view");
    }
}
