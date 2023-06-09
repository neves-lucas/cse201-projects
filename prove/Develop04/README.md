# Mindfulness Program

This is a C# program that provides three different kinds of mindfulness activities: breathing, reflection, and listing. It helps the user relax, reflect, and appreciate the good things in their life.

## How to use

To use this program, you need to have a C# compiler and a text editor. You can download Visual Studio Community Edition for free from [here](https://visualstudio.microsoft.com/vs/community/).

To run the program, follow these steps:

1. Open Visual Studio and create a new console application project.
2. Copy the files Activity.cs, BreathingActivity.cs, PromptActivity.cs, ReflectionActivity.cs, ListingActivity.cs, and Program.cs into the project folder.
3. Build and run the project.
4. Follow the instructions on the console to choose an activity and enter the duration.
5. Enjoy the mindfulness activity.

## How it works

This program uses inheritance, encapsulation, and abstraction to implement the different activities. It has a base class called Activity that contains common attributes and behaviors for all activities, such as the duration, the description, the start and end messages, and the pause method. It also has an abstract method called Perform that each subclass must override to perform the specific activity.

There are three subclasses of Activity that represent the three activities: BreathingActivity, ReflectionActivity, and ListingActivity. Each subclass has its own constructor that sets the description and any other specific attributes. Each subclass also overrides the Perform method to display the messages and prompts for the activity and loop until the duration is reached.

There is another abstract subclass of Activity called PromptActivity that represents an activity that involves prompts. It has a private member variable that stores a list of prompts for the activity and a method to get a random prompt from the list. It also has an abstract method called NewPrompt that each subclass must override to display a new prompt.

The ReflectionActivity and ListingActivity classes inherit from PromptActivity and override the NewPrompt method to display a random prompt from their respective lists. They also override the Perform method to display questions or count items based on the prompt.

The Program class contains the main method that runs the program. It creates an object of each activity class and displays a menu system to allow the user to choose an activity. It then calls the Perform method of the chosen activity object and repeats until the user chooses to exit.

