// GoalManager.cs

using System;
using System.Collections.Generic;
using System.IO;

namespace GoalTracker
{
    // This is a class that handles all the logic and operations related to the goals and the score
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public List<Goal> GetGoals()
        {
            return _goals;
        }

        public void SetGoals(List<Goal> goals)
        {
            _goals = goals;
        }

        public int GetScore()
        {
            return _score;
        }

        public void SetScore(int score)
        {
            _score = score;
        }
        public GoalManager()
        {
            SetGoals(new List<Goal>());
            SetScore(0);
        }
        public void CreateNewGoal()
        {
            Console.WriteLine();
            Console.WriteLine("Create New Goal");
            Console.Write("Enter the name of the goal: ");
            string name = Console.ReadLine();
            Console.Write("Enter the description of the goal: ");
            string description = Console.ReadLine();
            Console.Write("Enter the value of the goal in points: ");
            int value = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose the type of the goal:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Enter your choice: ");
            string type = Console.ReadLine();

            switch (type)
            {
                case "1": // Simple goal 
                    SimpleGoal simpleGoal = new SimpleGoal(name, description, value);
                    GetGoals().Add(simpleGoal);
                    Console.WriteLine("Simple goal created successfully.");
                    break;
                case "2": // Eternal goal 
                    EternalGoal eternalGoal = new EternalGoal(name, description, value);
                    GetGoals().Add(eternalGoal);
                    Console.WriteLine("Eternal goal created successfully.");
                    break;
                case "3": // Checklist goal 
                    Console.Write("Enter how many times you want to accomplish this goal: ");
                    int times = int.Parse(Console.ReadLine());
                    Console.Write("Enter the bonus value for completing this goal: ");
                    int bonus = int.Parse(Console.ReadLine());
                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, value, times, bonus);
                    GetGoals().Add(checklistGoal);
                    Console.WriteLine("Checklist goal created successfully.");
                    break;
                default: // Invalid choice 
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 3.");
                    break;
            }
        }
        public void ListGoals()
        {
            Console.WriteLine();
            Console.WriteLine("List Goals");
            if (GetGoals().Count == 0)
            {
                Console.WriteLine("You have no goals. Please create some goals first.");
            }
            else
            {
                Console.WriteLine("You have " + GetGoals().Count + " goals:");
                foreach (Goal goal in GetGoals())
                {
                    Console.WriteLine(goal.ToString());
                }
            }
        }
        public void SaveGoals()
        {
            Console.WriteLine();
            Console.WriteLine("Save Goals");
            Console.Write("Enter the file name to save the goals: ");
            string fileName = Console.ReadLine();
            File file = new File(fileName);
            file.SaveGoals(GetGoals(), GetScore());
        }

        public void LoadGoals()
        {
            Console.WriteLine();
            Console.WriteLine("Load Goals");
            Console.Write("Enter the file name to load the goals: ");
            string fileName = Console.ReadLine();
            File file = new File(fileName);
            file.LoadGoals(GetGoals(), ref _score);
            Console.WriteLine("You have " + GetScore() + " points.");
        }
        public void RecordEvent()
        {
            Console.WriteLine();
            Console.WriteLine("Record Event");
            if (GetGoals().Count == 0)
            {
                Console.WriteLine("You have no goals. Please create some goals first.");
            }
            else
            {
                ListGoals();
                Console.WriteLine("Choose the goal you want to record:");
                for (int i = 0; i < GetGoals().Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + GetGoals()[i].GetName());
                }
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > GetGoals().Count)
                {
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to " + GetGoals().Count + ".");
                }
                else
                {
                    Goal goal = GetGoals()[choice - 1];
                    SetScore(goal.RecordEvent(GetScore()));
                    Console.WriteLine("You have " + GetScore() + " points.");
                }
                
            }
        }
    }
}
