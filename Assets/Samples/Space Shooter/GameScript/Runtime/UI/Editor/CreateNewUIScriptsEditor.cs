using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateNewUIScriptsEditor : EditorWindow
{

    [MenuItem("Template Script/Create")]
    static void OpenEditor()
    {
        //创建窗口
        GetWindowWithRect<CreateNewUIScriptsEditor>(new Rect(100, 100, 300, 200), false, "Create");
    }
    //输入的名字
    private string scriptName = "Xxx";
    private string namespaceName = "";

    //模板文件路径
    private readonly string PATH_TO_PRESENTER_TEMPLATE = "Assets/Samples/Space Shooter/GameScript/Runtime/UI/UI/Common/TemplatePresenter.cs";
    private readonly string PATH_TO_CONTROLLER_TEMPLATE = "Assets/Samples/Space Shooter/GameScript/Runtime/UI/UI/Common/TemplateController.cs";


    /// <summary>
    /// 绘制窗口布局
    /// </summary>
    void OnGUI()
    {
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        GUILayout.Label("===================================");
        GUILayout.BeginHorizontal();
        GUILayout.Label("script:");
        scriptName = GUILayout.TextField(scriptName, 30);
        GUILayout.EndHorizontal();


        GUILayout.BeginHorizontal();
        GUILayout.Label("namespace:");
        namespaceName = GUILayout.TextField(namespaceName, 30);
        GUILayout.EndHorizontal();


        EditorGUILayout.Space();
        GUILayout.Label("===================================");
        var tmpNameSpace = namespaceName == "" ? "" : "." + namespaceName;
        GUI.color = Color.cyan;
        GUILayout.Label(string.Format("namespace: Client.UI{0}", tmpNameSpace));
        GUILayout.Label(string.Format("controller: {0}Controller", scriptName));
        GUILayout.Label(string.Format("presenter: {0}Presenter", scriptName));

        EditorGUILayout.Space();

        if (GUILayout.Button("生成MVC脚本"))
        {
            Create();
        }
    }

    void Create()
    {
        //根据输入的名字动态生成脚本
        var presenter = string.Format("{0}Presenter", scriptName);
        var controller = string.Format("{0}Controller", scriptName);

        //生成脚本路径
        var folderPath = "Assets/Samples/Space Shooter/GameScript/Runtime/UI/";
        //如果有命名空间，生成到对应的命名空间下
        if (namespaceName != null && namespaceName != "")
        {
            folderPath = string.Format("Assets/Samples/Space Shooter/GameScript/Runtime/UI{0}/", namespaceName);
            //如果没有文件夹，创建文件夹
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        //生成脚本
        var presenterPath = folderPath + presenter + ".cs";
        var controllerPath = folderPath + controller + ".cs";

        //如果文件不存在，复制模板文件
        if (!File.Exists(presenterPath))
        {
            //复制模板文件
            File.Copy(PATH_TO_PRESENTER_TEMPLATE, Path.Combine(folderPath, presenter + ".cs"));
            //读取模板文件内容
            var text = File.ReadAllText(presenterPath);
            //替换模板内容
            text = text.Replace("TemplatePresenter", presenter);
            //替换模板内容
            text = text.Replace("TemplateController", controller);
            //替换命名空间
            if (namespaceName != null && namespaceName != "")
            {
                text = text.Replace("namespace Client.UI", string.Format("namespace Client.UI.{0}", namespaceName));
            }
            //写入新文件
            File.WriteAllText(presenterPath, text);
        }

        if (!File.Exists(controllerPath))
        {
            File.Copy(PATH_TO_CONTROLLER_TEMPLATE, Path.Combine(folderPath, controller + ".cs"));
            var text = File.ReadAllText(controllerPath);
            text = text.Replace("TemplatePresenter", presenter);
            text = text.Replace("TemplateController", controller);
            if (namespaceName != null && namespaceName != "")
            {
                text = text.Replace("namespace Client.UI", string.Format("namespace Client.UI.{0}", namespaceName));
            }
            File.WriteAllText(controllerPath, text);
        }

        //刷新资源
        AssetDatabase.Refresh();
    }
}
