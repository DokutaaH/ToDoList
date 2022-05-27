using System;

namespace ToDoList
{
    /* 
    Список задач
    + Добавлять задачу
    + Удалять задачу
    + Помечать задачу как выполненную
    + Редактировать задачу

    Задача
    + Название
    + Дата создания
    + Статус задачи

    Статусы задачи: 
    + Новая
    + Выполненная

     */
    internal class Program
    {
        private static IssueList _issueList;
        private static void Main(string[] args)
        {
            PrintMenu();

            _issueList = new IssueList(100);
            bool isContinue = true;

            while (isContinue)
            {
                string operation = Console.ReadLine();

                switch (operation.ToLower())
                {
                    case Operations.SHOW_ISSUES_LIST:
                        PrintIssues();
                        break;

                    case Operations.ADD_NEW_ISSUE:
                        CreateNewIssue();
                        break;

                    case Operations.REMOVE_ISSUE:
                        DeleteIssue();
                        break;

                    case Operations.EDIT_ISSUE:
                        EditIssue();
                        break;

                    case Operations.SET_ISSUE_AS_DONE:
                        SetIssueAsDone();
                        break;

                    case Operations.EXIT:
                        isContinue = false;
                        break;

                    default:
                        Console.WriteLine($"Команды {operation} не существует ");
                        break;
                }

                if (isContinue)
                {
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadLine();
                    Console.Clear();
                    PrintMenu();
                }
            }
        }

        private static void SetIssueAsDone()
        {
            int selectedIssueNumber = GetIssueNumber();
            _issueList.MarkAsDone(selectedIssueNumber);
            Console.WriteLine("Задача помечена как выполненная");
        }

        private static void DeleteIssue()
        {
            int selectedIssueNumber = GetIssueNumber();
            _issueList.Delete(selectedIssueNumber);
            Console.WriteLine("Задача удалена");
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1 - Вывести список задач");
            Console.WriteLine("2 - Добавить задачу");
            Console.WriteLine("3 - Удалить задачу");
            Console.WriteLine("4 - Редактировать задачу");
            Console.WriteLine("5 - Пометить задачу как выполненную");
            Console.WriteLine("x - Выход");
        }

        private static void EditIssue()
        {
            int selectedIssueNumber = GetIssueNumber();

            Console.Write("Введите новую задачу: ");
            string newTitle = Console.ReadLine();

            _issueList.EditTitle(selectedIssueNumber, newTitle);
            Console.WriteLine("Задача отредактирована");
            Console.WriteLine();
        }

        private static void CreateNewIssue()
        {
            Console.Write("Впишите новую задачу и нажмите Enter: ");
            string title = Console.ReadLine();

            Issue newIssue = new Issue()
            {
                Title = title
            };

            _issueList.Add(newIssue);

            Console.WriteLine("Добавлена задача: " + newIssue.Title);
            Console.WriteLine();
        }

        private static void PrintIssues()
        {
            Issue[] issues = _issueList.GetIssues();

            for (int i = 0; i < issues.Length; i++)
            {
                Issue issue = issues[i];
                int issueNumber = i + 1;

                Console.WriteLine($"{issueNumber}) {issue.Title}, Статус: {issue.Status}");
            }

            Console.WriteLine();
        }

        private static int GetIssueNumber()
        {
            Issue[] issues = _issueList.GetIssues();

            for (int i = 0; i < issues.Length; i++)
            {
                Issue issue = issues[i];
                int issueNumber = i + 1;

                Console.WriteLine($"{issueNumber}) {issue.Title}, Статус: {issue.Status}");
            }

            int selectedIssueNumber;
            bool isSuccess;

            do
            {
                Console.Write("Введите номер задачи: ");
                string userInput = Console.ReadLine();
                isSuccess = int.TryParse(userInput, out selectedIssueNumber);

                if (selectedIssueNumber < 1 || selectedIssueNumber > issues.Length)
                {
                    isSuccess = false;
                }

            } while (isSuccess == false);

            return selectedIssueNumber;
        }
    }
}
