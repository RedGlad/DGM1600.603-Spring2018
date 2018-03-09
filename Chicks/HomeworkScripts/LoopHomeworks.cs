using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopHomeworks : MonoBehavior {
    void LogicalOperators() {
        if (Input.GetKeyDown(KeyCode.H) && Input.GetKeyDown(KeyCode.G)) {
            print("H AND G were pressed.")
        }
        if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.G)) {
            print("Either H OR G was pressed.")
        }
    }
    void WhileLoops() {
        int pizzaSlice = 7;

        while (pizzaSlice < 7) {
            print("I'm eating another pizza.");
            pizzaSlice ++;
        }
        if (pizzaSlice >= 7) {
            print("No more, I'm too full!")
        }
    }
    void ForLoops() {
        int badGuys = 7;

        for (int i = 0; i < badGuys; i++) {
            print("A bad guy attacks!");
        }
    }
    void ForEachLoops() {
        string[] names = new string[5];

        names[0] = "Jerry";
        names[1] = "Bob";
        names[2] = "Susan";
        names[3] = "Carlie";
        names[4] = "California";

        foreach (string item in names)
        {
            print(item + " fell in a hole!")
        }
    }
}