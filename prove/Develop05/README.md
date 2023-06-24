# Goal Tracker

Goal Tracker is a simple console application that allows the user to create, list, save, load and record different kinds of goals and keep track of their score.

## Classes

The program has five classes: Goal, SimpleGoal, EternalGoal, ChecklistGoal and File.

- The Goal class is the abstract base class for all kinds of goals. It has four member variables: name, value, completed and description. It also has getters and setters for these variables. It has a constructor that takes the name, description and value of the goal as parameters. It has an abstract method called RecordEvent that takes the user's score as a parameter and returns the updated score after recording an event. It also has a virtual method called ToString that returns a string representation of the goal.
- The SimpleGoal class inherits from the Goal class and represents a simple goal that can be marked complete and the user gains some value. It has a constructor that takes the name and value of the goal as parameters. It overrides the RecordEvent method to update the user's score and mark the goal as completed when recording an event. It also overrides the ToString method to add a check mark if the goal is completed.
- The EternalGoal class inherits from the Goal class and represents an eternal goal that is never complete, but each time the user records it, they gain some value. It has a constructor that takes the name and value of the goal as parameters. It overrides the RecordEvent method to update the user's score when recording an event. It also overrides the ToString method to add an infinity symbol.
- The ChecklistGoal class inherits from the Goal class and represents a checklist goal that must be accomplished a certain number of times to be complete. It has three additional member variables: times, count and bonus. It also has getters and setters for these variables. It has a constructor that takes the name, value, times and bonus of the goal as parameters. It overrides the RecordEvent method to update the user's score and the count when recording an event. It also checks if the count reaches the required times and adds the bonus value to the score and marks the goal as completed. It also overrides the ToString method to add a check mark if the goal is completed and show the current count and times.
- The File class is a helper class that handles the file operations for saving and loading the goals and the score. It has one member variable: fileName. It also has a getter and setter for this variable. It has a constructor that takes the file name as a parameter. It has two methods: SaveGoals and LoadGoals. The SaveGoals method takes a list of goals and a score as parameters and writes them to a file in a comma-separated format. The LoadGoals method takes a list of goals and a reference to a score as parameters and reads them from a file in a comma-separated format.

## Usage

To run the program, compile all the .cs files using `csc *.cs` command in your terminal or command prompt. Then run `GoalTracker.exe` file.

The program will display a welcome message and show your current score (which is zero by default). Then it will display a menu with six options:

1. Create New Goal
2. List Goals
3. Save Goals
4. Load Goals
5. Record Event
6. Quit

You can select an option by entering its number.

- If you select option 1, you will be prompted to enter the name, value and type of your new goal. You can choose from three types of goals: Simple Goal, Eternal Goal or Checklist Goal. If you choose Checklist Goal, you will also be prompted to enter how many times you want to accomplish this goal and what bonus value you will get for completing it.
- If you select option 2, you will see a list of all your goals with their names, values, completion status and other details depending on their type.
- If you select option 3, you will be prompted to enter a file name to save your goals and score to that file.
- If you select option 4, you will be prompted to enter a file name to load your goals and score from that file.
- If you select option 5, you will see a list of your goals with their names and numbers. You can choose which goal you want to record by entering its number. Your score will be updated according to the logic of that goal type.
- If you select option 6, you will quit the program.

You can repeat these steps until you choose to quit.

## Example

Here is an example of how to use the program:

