# Assignment Program

This program is a simple example of how to use inheritance and polymorphism in C#. It defines four classes: Assignment, MathAssignment, WritingAssignment, and Program.

## Assignment Class

The Assignment class is the base class for all types of assignments. It has two private fields: _studentName and _topic, which store the name of the student and the topic of the assignment. It also has a constructor that takes two parameters: studentName and topic, and assigns them to the fields. The Assignment class has three public methods: GetStudentName, GetTopic, and GetSummary. The GetStudentName and GetTopic methods return the values of the corresponding fields. The GetSummary method returns a string that contains the student name and the topic separated by a dash.

## MathAssignment Class

The MathAssignment class inherits from the Assignment class and represents a math assignment with a textbook section and a list of problems. It has two private fields: _textbookSection and _problems, which store the section number and the problems to be solved. It also has a constructor that takes four parameters: studentName, topic, textbookSection, and problems, and passes the first two to the base constructor, and assigns the last two to the fields. The MathAssignment class has one public method: GetHomeworkList. The GetHomeworkList method returns a string that contains the section number and the problems separated by a space.

## WritingAssignment Class

The WritingAssignment class inherits from the Assignment class and represents a writing assignment with a title. It has one private field: _title, which stores the title of the writing. It also has a constructor that takes three parameters: studentName, topic, and title, and passes the first two to the base constructor, and assigns the last one to the field. The WritingAssignment class has one public method: GetWritingInformation. The GetWritingInformation method returns a string that contains the title and the student name separated by a space.

## Program Class

The Program class contains the main method that creates and prints some instances of different types of assignments. It uses the Console.WriteLine method to display the output on the screen. It also demonstrates how polymorphism works by calling the GetSummary method on different types of assignments.
