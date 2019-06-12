﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class QuizDataEditor : EditorWindow {

    public Quiz quiz;
    private string quizDataPath;

    private Vector2 scrollPosition = Vector2.zero;
    private SerializedObject serializedObject;
    private SerializedProperty serializedProperty;

    [MenuItem("SchnitzeljagdAR/QuizDataEditor")]
    static void Init() {
        QuizDataEditor window = GetWindow<QuizDataEditor>("QuizDataEditor");
        window.minSize = new Vector2(600, 600);
        window.Show();
    }

    private void OnEnable() {
        quizDataPath = Path.Combine(Application.dataPath, "Quiz/Data/QuizData.json");

        ReadQuizData(quizDataPath);
        RefreshObject();
    }

    private void OnGUI() {

        #region Header Section
        Rect headerRect = new Rect(8, 8, this.position.width - 16, 40);
        GUI.Box(headerRect, GUIContent.none);

        GUIStyle headerStyle = new GUIStyle(EditorStyles.largeLabel) {
            fontSize = 26,
            alignment = TextAnchor.MiddleCenter
        };

        GUI.Label(headerRect, "Quiz Data Editor", headerStyle);
        #endregion

        #region Body Section
        Rect bodyRect = new Rect(8, (headerRect.y + headerRect.height) + 8, this.position.width - 16, this.position.height - (headerRect.y + headerRect.height) - 80);
        GUI.Box(bodyRect, GUIContent.none);

        Rect viewRect = new Rect(bodyRect.x + 8, bodyRect.y + 8, bodyRect.width - 16, EditorGUI.GetPropertyHeight(serializedProperty));
        Rect scrollPosRect = new Rect(viewRect) {
            height = bodyRect.height - 20
        };

        scrollPosition = GUI.BeginScrollView(scrollPosRect, scrollPosition, viewRect, false, false, GUIStyle.none, GUI.skin.verticalScrollbar);

        bool drawSlider = viewRect.height > scrollPosRect.height;
        Rect propertyRect = new Rect(bodyRect.x + 8, bodyRect.y + 8, bodyRect.width - (drawSlider ? 40 : 20), 17);
        EditorGUI.PropertyField(propertyRect, serializedProperty, true);
        serializedObject.ApplyModifiedProperties();

        GUI.EndScrollView();
        #endregion

        #region Navigation
        Rect buttonRect = new Rect(bodyRect.x + bodyRect.width - 85, bodyRect.y + bodyRect.height + 16, 80, 30);
        bool pressedSave = GUI.Button(buttonRect, "Save", EditorStyles.miniButtonRight);
        if(pressedSave) {
            WriteQuizData(quizDataPath);
        }
        buttonRect.x -= buttonRect.width;
        bool pressedLoad = GUI.Button(buttonRect, "Load", EditorStyles.miniButtonLeft);
        if(pressedLoad) {
            ReadQuizData(quizDataPath);

            RefreshObject();
        }
        buttonRect.x = bodyRect.x;
        bool pressedNew = GUI.Button(buttonRect, "New", EditorStyles.miniButton);
        if(pressedNew) {
            quiz = new Quiz();
            quiz.Stages = new Quiz.Stage[0];
            quizDataPath = Path.Combine(Application.dataPath, "Quiz/Data/QuizData.json");

            RefreshObject();
        }

        #endregion
    }

    private void RefreshObject() {
        serializedObject = new SerializedObject(this);
        serializedProperty = serializedObject.FindProperty("quiz").FindPropertyRelative("stages");

        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
    }

    private void ReadQuizData(string path) {
        if(File.Exists(path)) {
            string quizDataAsJson = File.ReadAllText(path);
            quiz = JsonUtility.FromJson<Quiz>(quizDataAsJson);
        } else {
            quiz = new Quiz();
            quiz.Stages = new Quiz.Stage[0];
        }
    }

    private void WriteQuizData(string path) {
        if(File.Exists(path)) {
            string date = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string quizDataPathBackup = quizDataPath.Replace("QuizData", "QuizDataBackup" + date);
            File.Copy(quizDataPath, quizDataPathBackup);
        }

        string quizDataAsJson = JsonUtility.ToJson(quiz, true);
        File.WriteAllText(path, quizDataAsJson);
    }
    public void TestWriteQuiz() {
        int indexStages = 12;
        int indexQuestions = 4;
        Quiz.Stage[] stages = new Quiz.Stage[indexStages];

        for(int i = 0; i < stages.Length; i++) {
            stages[i] = new Quiz.Stage(new Question[indexQuestions]);

            for(int j = 0; j < indexQuestions; j++) {
                string index = "[" + i + "." + j + "]";
                stages[i].Questions[j] = new Question("Question" + index, new Question.Answer[] {
                new Question.Answer("Right", true),
                new Question.Answer("Wrong", false),
                new Question.Answer("Wrong", false),
                new Question.Answer("Wrong", false)
                });
            }
        }

        string json = MyJsonUtility.ToJson(stages, true);
        File.WriteAllText(quizDataPath.Replace(".json", "") + "Test.json", json);
    }
}
