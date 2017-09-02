using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Graph", menuName = "Node Graph")]
public class NodeGraph : ScriptableObject {
    [HideInInspector]
    public List<Node> nodes = new List<Node>(0);
}