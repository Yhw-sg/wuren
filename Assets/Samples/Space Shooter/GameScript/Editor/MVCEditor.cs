using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class MVCEditor : EditorWindow
{
    private string Name = "NewScripts";
    private string path=Application.dataPath+"/Scripts/MVC/UI/";
    [MenuItem("Editor/MVCEditor")]
    static void CreateScript()
    {
        MVCEditor mVC=GetWindow<MVCEditor>("MVCScript");
        mVC.maxSize = new Vector2(800, 600);
    }
    private void OnGUI()
    {
        Name = EditorGUILayout.TextField("ScriptName",Name);
        if (GUILayout.Button(("生成MVC脚本")))
        {
            CreateMVCScripts(Name);
        }
    }

    private void CreateMVCScripts(string name)
    {
        string MVCPath=path+name;
        if(!Directory.Exists(MVCPath))
        {
            Directory.CreateDirectory(MVCPath);
            Debug.Log("文件路径创建成功");
        }
        else
        {
            Debug.Log("该文件夹已存在");
        }
        string MVCControl=Path.Combine(MVCPath,name+ "Control.cs");
        string MVCView=Path.Combine(MVCPath,name+ "View.cs");
        string MVCModel=Path.Combine(MVCPath,name+ "Model.cs");
        if(!File.Exists(MVCControl))
        {
            string scriptControl = "using UnityEngine;\n\npublic class " + name+ "Control :ControlBase\n{\n\n}";
            File.WriteAllText(MVCControl, scriptControl);
        }
        else
        {
            Debug.Log("Control脚本已存在");
        }
        if(!File.Exists(MVCView))
        {
            string scriptView = "using UnityEngine;\n\npublic class " + name+ "View :ViewBase\n{\n\n}";
            File.WriteAllText(MVCView, scriptView);
        }
        else
        {
            Debug.Log("View脚本已存在");
        }
        if(!File.Exists(MVCModel))
        {
            string scriptModel = "using UnityEngine;\n\npublic class " + name+ "Model :ModelBase\n{\n\n}";
            File.WriteAllText(MVCModel, scriptModel);
        }
        else
        {
            Debug.Log("Model脚本已存在");
        }

        
    }
}
