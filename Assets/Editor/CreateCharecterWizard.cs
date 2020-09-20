using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateCharecterWizard : ScriptableWizard
{
    public Texture2D portraitTexture;
    public Color color = Color.white;
    public string nickname = "Default nickname";

    [MenuItem("My Tools/Create Character Wizard...")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<CreateCharecterWizard>("Create Character", "Create new", "Update selected");
    }

    private void OnWizardCreate()
    {
        GameObject characterGO = new GameObject();

        Character characterComponent = characterGO.AddComponent<Character>();
        characterComponent.portrait = portraitTexture;
        characterComponent.color = color;
        characterComponent.nickname = nickname;

    }

    private void OnWizardOtherButton()
    {
        if (Selection.activeTransform != null)
        {
            Character characterComponent = Selection.activeTransform.GetComponent<Character>();

            if (characterComponent != null)
            {
                characterComponent.portrait = portraitTexture;
                characterComponent.color = color;
                characterComponent.nickname = nickname;
            }
        }
    }

    private void OnWizardUpdate()
    {
        helpString = "Enter character details";
    }
}
