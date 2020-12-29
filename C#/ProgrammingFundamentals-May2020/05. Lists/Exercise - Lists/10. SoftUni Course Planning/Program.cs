using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Proccessing(schedule);
            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i+1}.{schedule[i]}");
            }
        }
        static void Proccessing(List<string> schedule)
        {
            string command;
            while ((command = Console.ReadLine()) != "course start")
            {
                string[] cmdArgs = command.Split(":");
                switch (cmdArgs[0])
                {
                    case "Add":
                        AddLessonToSchedule(cmdArgs[1], schedule);
                        break;
                    case "Insert":
                        InsertLessonToSchedule(schedule, cmdArgs[1], int.Parse(cmdArgs[2]));
                        break;
                    case "Remove":
                        RemoveLessonFromSchedule(schedule, cmdArgs[1]);
                        break;
                    case "Swap":
                        SwapLessonsFromSchedule(schedule, cmdArgs[1], cmdArgs[2]);
                        break;
                    case "Exercise":
                        AddExerciseLessonsToSchedule(schedule, cmdArgs[1]);
                        break;
                }
            }
        }
        static void AddExerciseLessonsToSchedule(List<string> list, string lessonTitle)
        {
            string exerciseTitle = lessonTitle + "-Exercise";
            if (list.Contains(lessonTitle))
            {
                if (!list.Contains(exerciseTitle))
                {
                    int lessonIndex = list.IndexOf(lessonTitle);
                    list.Insert(lessonIndex + 1, exerciseTitle);
                }
            }
            else
            {
                list.Add(lessonTitle);
                list.Add(exerciseTitle);
            }
        }
        static void SwapLessonsFromSchedule(List<string> list, string lessonTitle, string lessonTitleToSwap)
        {
            string exerciseTitle = lessonTitle + "-Exercise";
            string exerciseTitleToSwap = lessonTitleToSwap + "-Exercise";
            if (list.Contains(lessonTitle) && list.Contains(lessonTitleToSwap))
            {
                int firstLessonIndex = list.IndexOf(lessonTitle);
                int secondLessonIndex = list.IndexOf(lessonTitleToSwap);
                string temp = list[firstLessonIndex];
                list[firstLessonIndex] = lessonTitleToSwap;
                list[secondLessonIndex] = temp;
                if (list.Contains(exerciseTitle))
                {
                    int exerciseIndex = list.IndexOf(exerciseTitle);
                    list.RemoveAt(exerciseIndex);
                    list.Insert(secondLessonIndex + 1, exerciseTitle);
                }
                if (list.Contains(exerciseTitleToSwap))
                {
                    int exerciseIndexToSwap = list.IndexOf(exerciseTitleToSwap);
                    list.RemoveAt(exerciseIndexToSwap);
                    list.Insert(firstLessonIndex+1, exerciseTitleToSwap);
                }
            }
        }
        static void RemoveLessonFromSchedule(List<string> list, string lessonTitle)
        {
            string exerciseTitle = lessonTitle + "-Exercise";
            if (list.Contains(lessonTitle))
            {
                list.Remove(lessonTitle);
                if (list.Contains(exerciseTitle))
                {
                    list.Remove(exerciseTitle);
                }
            }
        }
        static void InsertLessonToSchedule(List<string> list, string lessonTitle, int index)
        {
            if (!list.Contains(lessonTitle))
            {
                list.Insert(index, lessonTitle);
            }
        }
        static void AddLessonToSchedule(string lessonTitle, List<string> list)
        {
            if (!list.Contains(lessonTitle))
            {
                list.Add(lessonTitle);
            }
        }
    }
}
