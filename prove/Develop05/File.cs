namespace GoalTracker
{
    public class File
    {
        private string _fileName;
        public string GetFileName()
        {
            return _fileName;
        }
        public void SetFileName(string fileName)
        {
            _fileName = fileName;
        }
        public File(string fileName)
        {
            SetFileName(fileName);
        }
        public void SaveGoals(List<Goal> goals, int score)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(GetFileName()))
                {
                    writer.WriteLine(score);
                    foreach (Goal goal in goals)
                    {
                        writer.WriteLine(goal.GetType().Name + "," + goal.GetName() + "," + goal.GetValue() + "," + goal.GetCompleted());
                        if (goal is ChecklistGoal)
                        {
                            ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                            writer.WriteLine(checklistGoal.GetTimes() + "," + checklistGoal.GetCount() + "," + checklistGoal.GetBonus());
                        }
                    }
                }
                Console.WriteLine("Goals saved successfully to " + GetFileName() + ".");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving goals: " + e.Message);
            }
        }
        public void LoadGoals(List<Goal> goals, ref int score)
        {
            try
            {
                using (StreamReader reader = new StreamReader(GetFileName()))
                {
                    score = int.Parse(reader.ReadLine());
                    goals.Clear();
                    while (!reader.EndOfStream)
                    {
                        string[] fields = reader.ReadLine().Split(',');
                        string type = fields[0];
                        string name = fields[1];
                        string description = fields[2];
                        int value = int.Parse(fields[3]);
                        bool completed = bool.Parse(fields[4]);
                        
                        switch (type)
                        {
                            case "SimpleGoal":
                                SimpleGoal simpleGoal = new SimpleGoal(name, description, value);
                                simpleGoal.SetCompleted(completed);
                                goals.Add(simpleGoal);
                                break;
                            case "EternalGoal":
                                EternalGoal eternalGoal = new EternalGoal(name, description, value);
                                eternalGoal.SetCompleted(completed);
                                goals.Add(eternalGoal);
                                break;
                            case "ChecklistGoal":
                                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, value, 0, 0);
                                checklistGoal.SetCompleted(completed);
                                fields = reader.ReadLine().Split(',');
                                int times = int.Parse(fields[0]);
                                int count = int.Parse(fields[1]);
                                int bonus = int.Parse(fields[2]);
                                checklistGoal.SetTimes(times);
                                checklistGoal.SetCount(count);
                                checklistGoal.SetBonus(bonus);
                                goals.Add(checklistGoal);
                                break;
                            default:
                                Console.WriteLine("Invalid goal type: " + type);
                                break;
                        }
                    }
                }
                Console.WriteLine("Goals loaded successfully from " + GetFileName() + ".");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error loading goals: " + e.Message);
            }
        }
    }
}
