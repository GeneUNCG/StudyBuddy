﻿using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace StudyBuddy
{
    public partial class NewCardsForm : Form
    {
        public NewCardsForm()
        {
            InitializeComponent();
        }

        string currentQuizFile = Properties.Settings.Default.QuizDirectory + @"\" + Properties.Settings.Default.currentSelectedQuiz + ".xml";
        XmlDocument xmlDoc = new XmlDocument();

        private void NewCardsForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.backButtonPressed || Properties.Settings.Default.editMode)
            {
                xmlDoc.Load(currentQuizFile); // Loads the XML
                quizNameTextBox.Text = xmlDoc.SelectSingleNode("StudyBuddy/TestInfo/TestName").InnerText;
                questionNumbersComboBox.Text = xmlDoc.SelectSingleNode("StudyBuddy/TestInfo/NumberOfTestQuestions").InnerText;
            }
            else
            {
                questionNumbersComboBox.SelectedIndex = 0;
            }
        }

        private void cardGroupNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(Properties.Settings.Default.QuizDirectory + @"\" + quizNameTextBox.Text + ".xml") && quizNameTextBox.Text != Properties.Settings.Default.currentSelectedQuiz)
            {
                nextButton.Enabled = false;
                alreadyExistsLabel.Text = "The quiz '" + quizNameTextBox.Text + "' already exists.";
                alreadyExistsLabel.Visible = true;
            }
            else if (quizNameTextBox.Text == "")
            {
                nextButton.Enabled = false;
                alreadyExistsLabel.Text = "Please enter a valid quiz name.";
                alreadyExistsLabel.Visible = true;
            }
            else
            {
                nextButton.Enabled = true;
                alreadyExistsLabel.Visible = false;
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.editMode)
            {
                if (!File.Exists(Properties.Settings.Default.QuizDirectory + @"\" + quizNameTextBox.Text + ".xml"))
                {
                    XmlTextWriter xWriter = new XmlTextWriter(Properties.Settings.Default.QuizDirectory + @"\" + quizNameTextBox.Text + ".xml", Encoding.UTF8);
                    xWriter.Formatting = Formatting.Indented;
                    xWriter.WriteStartElement("StudyBuddy"); // <StudyBuddy>
                    xWriter.WriteStartElement("TestInfo"); // <TestInfo>
                    xWriter.WriteStartElement("TestName"); // <TestName>
                    xWriter.WriteString(quizNameTextBox.Text); // quizNameNameTextBox.Text
                    xWriter.WriteEndElement(); // </TestName>
                    xWriter.WriteStartElement("NumberOfTestQuestions"); // <NumberOfTestQuestions>
                    xWriter.WriteString(questionNumbersComboBox.Text); // questionNumbersComboBox.Text
                    xWriter.WriteEndElement(); // </NumberOfTestQuestions>
                    xWriter.WriteEndElement(); // </TestInfo>

                    if (questionNumbersComboBox.SelectedIndex >= 0)
                    {
                        // Write the questions.
                        xWriter.WriteStartElement("QuestionInfo"); // <QuestionInfo>
                        xWriter.WriteStartElement("Question1"); // <Question1>
                        xWriter.WriteEndElement(); // </Question1>
                        if (questionNumbersComboBox.SelectedIndex >= 1)
                        {
                            xWriter.WriteStartElement("Question2"); // <Question2>
                            xWriter.WriteEndElement(); // </Question2>

                            if (questionNumbersComboBox.SelectedIndex >= 2)
                            {
                                xWriter.WriteStartElement("Question3"); // <Question3>
                                xWriter.WriteEndElement(); // </Question3>

                                if (questionNumbersComboBox.SelectedIndex >= 3)
                                {
                                    xWriter.WriteStartElement("Question4"); // <Question4>
                                    xWriter.WriteEndElement(); // </Question4>

                                    if (questionNumbersComboBox.SelectedIndex >= 4)
                                    {
                                        xWriter.WriteStartElement("Question5"); // <Question5>
                                        xWriter.WriteEndElement(); // </Question5>

                                        if (questionNumbersComboBox.SelectedIndex >= 5)
                                        {
                                            xWriter.WriteStartElement("Question6"); // <Question6>
                                            xWriter.WriteEndElement(); // </Question6>

                                            if (questionNumbersComboBox.SelectedIndex >= 6)
                                            {
                                                xWriter.WriteStartElement("Question7"); // <Question7>
                                                xWriter.WriteEndElement(); // </Question7>

                                                if (questionNumbersComboBox.SelectedIndex >= 7)
                                                {
                                                    xWriter.WriteStartElement("Question8"); // <Question8>
                                                    xWriter.WriteEndElement(); // </Question8>

                                                    if (questionNumbersComboBox.SelectedIndex >= 8)
                                                    {
                                                        xWriter.WriteStartElement("Question9"); // <Question9>
                                                        xWriter.WriteEndElement(); // </Question9>

                                                        if (questionNumbersComboBox.SelectedIndex == 9)
                                                        {
                                                            xWriter.WriteStartElement("Question10"); // <Question10>
                                                            xWriter.WriteEndElement(); // </Question10>
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        xWriter.WriteEndElement(); // </QuestionInfo>

                        // Write the answers
                        xWriter.WriteStartElement("AnswerInfo");
                        xWriter.WriteStartElement("Answer1");
                        xWriter.WriteEndElement(); // </Answer1>
                        if (questionNumbersComboBox.SelectedIndex >= 1)
                        {
                            xWriter.WriteStartElement("Answer2"); // <Answer2>
                            xWriter.WriteEndElement(); // </Answer2>

                            if (questionNumbersComboBox.SelectedIndex >= 2)
                            {
                                xWriter.WriteStartElement("Answer3"); // <Answer3>
                                xWriter.WriteEndElement(); // </Answer3>

                                if (questionNumbersComboBox.SelectedIndex >= 3)
                                {
                                    xWriter.WriteStartElement("Answer4"); // <Answer4>
                                    xWriter.WriteEndElement(); // </Answer4>

                                    if (questionNumbersComboBox.SelectedIndex >= 4)
                                    {
                                        xWriter.WriteStartElement("Answer5"); // <Answer5>
                                        xWriter.WriteEndElement(); // </Answer5>

                                        if (questionNumbersComboBox.SelectedIndex >= 5)
                                        {
                                            xWriter.WriteStartElement("Answer6"); // <Answer6>
                                            xWriter.WriteEndElement(); // </Answer6>

                                            if (questionNumbersComboBox.SelectedIndex >= 6)
                                            {
                                                xWriter.WriteStartElement("Answer7"); // <Answer7>
                                                xWriter.WriteEndElement(); // </Answer7>

                                                if (questionNumbersComboBox.SelectedIndex >= 7)
                                                {
                                                    xWriter.WriteStartElement("Answer8"); // <Answer8>
                                                    xWriter.WriteEndElement(); // </Answer8>

                                                    if (questionNumbersComboBox.SelectedIndex >= 8)
                                                    {
                                                        xWriter.WriteStartElement("Answer9"); // <Answer9>
                                                        xWriter.WriteEndElement(); // </Answer9>

                                                        if (questionNumbersComboBox.SelectedIndex == 9)
                                                        {
                                                            xWriter.WriteStartElement("Answer10"); // <Answer10>
                                                            xWriter.WriteEndElement(); // </Answer10>
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        xWriter.WriteEndElement(); // </AnswerInfo>
                    }
                    xWriter.Close();
                }
            }
            else if (Properties.Settings.Default.editMode)
            {
                xmlDoc.Load(currentQuizFile);
                
                // If the user has changed the name, we will need to override the old xml file with the new name.
                if (xmlDoc.SelectSingleNode("StudyBuddy/TestInfo/TestName").InnerText != quizNameTextBox.Text)
                {
                    File.Move(currentQuizFile, Properties.Settings.Default.QuizDirectory + @"\" + quizNameTextBox.Text + ".xml");
                    currentQuizFile = Properties.Settings.Default.QuizDirectory + @"\" + quizNameTextBox.Text + ".xml";
                    xmlDoc.Load(currentQuizFile);
                    xmlDoc.SelectSingleNode("StudyBuddy/TestInfo/TestName").InnerText = quizNameTextBox.Text;
                    xmlDoc.Save(currentQuizFile);
                }
                // TODO: Change number of questions here.
            }
            Properties.Settings.Default.currentSelectedQuiz = quizNameTextBox.Text;
            Properties.Settings.Default.Save();
            Dispose();
            NewQuestionsForm nqf = new NewQuestionsForm();
            nqf.ShowDialog();
        }

        private void NewCardsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.backButtonPressed = false;
            Properties.Settings.Default.currentSelectedQuiz = null;
            Properties.Settings.Default.Save();
        }
    }
}