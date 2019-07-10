using System.IO;
using UnityEditor;
using UnityEngine;

public class QuizDataEditor : EditorWindow {

    #region Attributes
    // QuizData
    [SerializeField] private QuizData quizData;
    // GUI
    private Vector2 ScrollPosition { get; set; } = Vector2.zero;
    private SerializedObject SerializedObject { get; set; }
    private SerializedProperty SerializedProperty { get; set; }
    // QuizData Path
    private string QuizDataPath { get; set; }
    #endregion

    #region Getter and Setter
    public QuizData QuizData {
        get { return quizData; }
        set { quizData = value; }
    }
    #endregion

    #region UnityMethods
    [MenuItem("SchnitzeljagdAR/QuizDataEditor")]
    static void Init() {
        QuizDataEditor window = GetWindow<QuizDataEditor>("QuizDataEditor");
        window.minSize = new Vector2(600, 600);
        window.Show();
    }

    private void OnEnable() {
        QuizDataPath = QuizData.Path;
        ReadQuizData(QuizDataPath);
        RefreshObject();
    }

    private void OnGUI() {

        #region Header
        Rect headerRect = new Rect(8, 8, this.position.width - 16, 40);
        GUI.Box(headerRect, GUIContent.none);

        GUIStyle headerStyle = new GUIStyle(EditorStyles.largeLabel) {
            fontSize = 26,
            alignment = TextAnchor.MiddleCenter
        };

        GUI.Label(headerRect, "Quiz Data Editor", headerStyle);
        #endregion

        #region Body
        Rect bodyRect = new Rect(8, (headerRect.y + headerRect.height) + 8, this.position.width - 16, this.position.height - (headerRect.y + headerRect.height) - 80);
        GUI.Box(bodyRect, GUIContent.none);

        Rect viewRect = new Rect(bodyRect.x + 8, bodyRect.y + 8, bodyRect.width - 16, EditorGUI.GetPropertyHeight(SerializedProperty));
        Rect scrollPosRect = new Rect(viewRect) {
            height = bodyRect.height - 20
        };

        ScrollPosition = GUI.BeginScrollView(scrollPosRect, ScrollPosition, viewRect, false, false, GUIStyle.none, GUI.skin.verticalScrollbar);

        bool drawSlider = viewRect.height > scrollPosRect.height;
        Rect propertyRect = new Rect(bodyRect.x + 8, bodyRect.y + 8, bodyRect.width - (drawSlider ? 40 : 20), 17);
        EditorGUI.PropertyField(propertyRect, SerializedProperty, true);
        SerializedObject.ApplyModifiedProperties();

        GUI.EndScrollView();
        #endregion

        #region Navigation
        Rect buttonRect = new Rect(bodyRect.x + bodyRect.width - 85, bodyRect.y + bodyRect.height + 16, 80, 30);

        bool pressedSave = GUI.Button(buttonRect, "Save", EditorStyles.miniButtonRight);
        if(pressedSave) {
            WriteQuizData(QuizDataPath);
        }

        buttonRect.x -= buttonRect.width;
        bool pressedLoad = GUI.Button(buttonRect, "Load", EditorStyles.miniButtonLeft);
        if(pressedLoad) {
            ReadQuizData(QuizDataPath);

            RefreshObject();
        }

        buttonRect.x = bodyRect.x;
        bool pressedNew = GUI.Button(buttonRect, "New", EditorStyles.miniButton);
        if(pressedNew) {
            QuizData = new QuizData {
                Stages = new QuizData.Stage[0]
            };

            RefreshObject();
        }

        #endregion
    }
    #endregion

    #region Methods
    private void RefreshObject() {
        SerializedObject = new SerializedObject(this);
        SerializedProperty = SerializedObject.FindProperty("quizData").FindPropertyRelative("stages");

        SerializedObject.ApplyModifiedProperties();
        SerializedObject.Update();
    }

    private void ReadQuizData(string path) {
        if(File.Exists(path)) {
            QuizData = QuizData.ReadQuizData(path);
        }
        else {
            QuizData = new QuizData {
                Stages = new QuizData.Stage[0]
            };
        }
    }

    private void WriteQuizData(string path) {
        if(QuizData.QuizDataChecker(QuizData)) {
            if(File.Exists(path)) {
                string date = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string pathBackup = path.Replace("QuizData", "QuizDataBackup" + date);
                File.Copy(path, pathBackup);
            }

            string quizDataAsJson = JsonUtility.ToJson(QuizData, true);
            File.WriteAllText(path, quizDataAsJson);

            Debug.Log("QuizData is Correct and was saved!");
        } else {
            Debug.Log("QuizData is Incorrect and was not saved!");
        }
    }

    public void TestWriteQuiz() {
        int indexStages = 12;
        int indexQuestions = 4;
        QuizData.Stage[] stages = new QuizData.Stage[indexStages];

        for(int i = 0; i < stages.Length; i++) {
            stages[i] = new QuizData.Stage(new Question[indexQuestions]);

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
        File.WriteAllText(QuizDataPath.Replace(".json", "") + "Test.json", json);
    }
    #endregion
}
