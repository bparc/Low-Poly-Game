using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NodeEditor : EditorWindow {
    public Texture2D background;
    Vector2 viewOffset;
    Vector2 canvasSize;
    Vector2 canvasPosition = new Vector2(255.0f, 0.0f);

    NodeGraph target;

    [MenuItem("Window/Node Editor")]
    public static void ShowWindow() {
        GetWindow<NodeEditor>().titleContent = new GUIContent("Node Editor");
        GetWindow<NodeEditor>().Show();
    }

    void OnGUI() {
        UpdateCanvasSize();
        HandleMouseEvents();
        DrawGraph();
        DrawMenu();
    }

    void CreateNode(object position) {
        if (target) {
            //target.nodes.Add(new Node(new Rect(Event.current.mousePosition, new Vector2(250.0f, 400.0f))));
            target.nodes.Add(new Node(new Rect((Vector2)position, new Vector2(250.0f, 400.0f))));
        }
    }

    void ClearGraph() {
        if (target) {
            target.nodes.Clear();
        }
    }

    void HandleMouseEvents() {    
        if (Event.current.type == EventType.MouseDrag && Event.current.button == 2) {
            if (new Rect(canvasPosition, canvasSize).Contains(Event.current.mousePosition)) {
                float sensitivity = 1.0f;

                viewOffset.x -= Event.current.delta.x * sensitivity;
                viewOffset.y -= Event.current.delta.y * sensitivity;

                //if (viewOffset.x < 0.0f)
                //    viewOffset.x = 0.0f;
                //if (viewOffset.y < 0.0f)
                //    viewOffset.y = 0.0f;

                Repaint();
            }
        }

        if (Event.current.type == EventType.MouseDown && Event.current.button == 1) {
            if (new Rect(canvasPosition, canvasSize).Contains(Event.current.mousePosition)) {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("Create Node"), false, CreateNode, Event.current.mousePosition - canvasPosition + viewOffset); //TODO(Arc): Window position to canvas position.
                menu.AddItem(new GUIContent("Clear Graph"), false, ClearGraph);
                menu.ShowAsContext();
            }
        }
    }

    void UpdateCanvasSize() {
        canvasSize.x = position.size.x - canvasPosition.x;
        canvasSize.y = position.size.y;
    }

    void DrawCanvas() {
        GUI.DrawTextureWithTexCoords(
            new Rect(canvasPosition.x, canvasPosition.y + canvasSize.y,
            canvasSize.x, -canvasSize.y),
            background,
            new Rect(viewOffset.x / background.width, viewOffset.y / background.height,
            (canvasSize.x / (background.width)), (canvasSize.y / (background.height))));
    }

    void DrawGraph() {
        DrawCanvas();

        GUI.BeginGroup(new Rect(canvasPosition, canvasSize));
        {
            if (target) {
                foreach (Node node in target.nodes) {
                    DrawNode(node);
                }
            }
        }
        GUI.EndGroup();
    }

    void DrawNode(Node node) {
        GUI.Box(new Rect(node.window.position - viewOffset, node.window.size), "");
    }

    void DrawMenu() {
        //TODO(Arc): GUI layout

        float padding = 15.0f;

        GUILayout.BeginArea(new Rect(padding, 0.0f, canvasPosition.x - padding * 2.0f, position.y));
        {
            GUILayout.Space(5.0f);
            GUILayout.Label("Target: ", EditorStyles.boldLabel);
            target = (NodeGraph)EditorGUILayout.ObjectField(target, typeof(NodeGraph), false);
        }
        GUILayout.EndArea();
    }
}