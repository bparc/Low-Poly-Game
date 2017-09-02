using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : ScriptableObject {
    public Rect window;

    public Node(Rect window) {
        this.window = window;
    }
}