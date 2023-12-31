using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/New Story Scene")]
[System.Serializable]

public class StoryScene : ScriptableObject
{
    public List<Sentence> sentences;
    public Sprite background;
    public StoryScene nextScene;

    [System.Serializable]

    public struct Sentence
    {
        [TextArea(4, 20)]
        public string text;
        public Speaker speaker;
    }
}
