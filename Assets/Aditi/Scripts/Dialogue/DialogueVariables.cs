using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using Unity.VisualScripting;

public class DialogueVariables
{

    //dictionary of variables - variableName: value
    public Dictionary<string, Ink.Runtime.Object> variables = new Dictionary<string, Ink.Runtime.Object>();

    //public constructor
    public DialogueVariables(TextAsset globalsJson)
    {
        Story globalVariablesStory = new Story(globalsJson.text);

        foreach (string varName in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(varName);
            variables.Add(varName, value);
            Debug.Log("Initialized global dialogue variable: " + varName + " = " + value);
        }
    }

    //takes in the story object that we want the observer to listen to
    public void StartListening(Story story)
    {
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged; //adds this function as the listener for when a variable in this story changes
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged; //removes the listener
    }


    //when a variable changes in unity, this function will be called. parameters are string variable name and value of variable
    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        if (variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value);
        }
        else
        {
            Debug.LogError("Variable name not initialized in globals file: " + name);
        }
    }


    private void VariablesToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }

}
