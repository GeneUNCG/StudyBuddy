﻿using System;
using System.Windows.Forms;
using System.Xml;

namespace StudyBuddy
{
    public partial class StudyForm : Form
    {
        public StudyForm()
        {
            InitializeComponent();
        }

        XmlDocument xmlDoc = new XmlDocument();
        int totalQuestions;
        int currentIndex = 1;
        int wrongAnswers;
        int rightAnswers;

        string currentQuizFile = Application.StartupPath + @"\saved cards\" + Properties.Settings.Default.currentSelectedQuiz + ".xml";

        private void StudyForm_Load(object sender, EventArgs e)
        {
            xmlDoc.Load(currentQuizFile); // Loads the XML
            totalQuestions = int.Parse(xmlDoc.SelectSingleNode("StudyBuddy/TestInfo/NumberOfTestQuestions").InnerText); // Gets the number of questions.
            questionLabel.Text = xmlDoc.SelectSingleNode("StudyBuddy/QuestionInfo/Question1").InnerText; // Sets the question to the first question.
            centerQuestionLabel();
        }

        private void nextQuestionButton_Click(object sender, EventArgs e)
        {
            if (xmlDoc.SelectSingleNode("StudyBuddy/AnswerInfo/Answer" + currentIndex).InnerText != answerTextBox.Text)
            {
                wrongAnswers++;
            }
            else
            {
                rightAnswers++;
                nextQuestion();
            }
        }

        private void nextQuestion()
        {
            if (totalQuestions > currentIndex)
            {
                currentIndex++;
                questionLabel.Text = xmlDoc.SelectSingleNode("StudyBuddy/QuestionInfo/Question" + currentIndex).InnerText; // Sets the question to the next question.
                answerTextBox.Text = "";
                centerQuestionLabel();
            }
            else
            {
                int percentScore = (rightAnswers / totalQuestions) * 100;
                MessageBox.Show("Congratulations, you have finished this study session! You got " + rightAnswers + " correct and " + wrongAnswers + " wrong. Your final score is a " + percentScore + "%.");
                Dispose();
            }
        }

        private void centerQuestionLabel()
        {
            currentQuestionLabel.Left = (ClientSize.Width - currentQuestionLabel.Size.Width) / 2;
        }
    }
}
