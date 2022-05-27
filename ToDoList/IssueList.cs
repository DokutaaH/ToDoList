
namespace ToDoList
{
    class IssueList
    {
        private Issue[] _issues;
        public IssueList(int max)
        {
            _issues = new Issue[max];

            _issues[0] = new Issue
            {
                Title = "TEST1",
            };

            _issues[1] = new Issue
            {
                Title = "TEST2",
            };

            _issues[2] = new Issue
            {
                Title = "TEST3",
            };
        }

        public Issue[] GetIssues()
        {
            Issue[] definedIssues = new Issue[Count()];

            for (int i = 0; i < _issues.Length; i++)
            {
                if (_issues[i] != null)
                {
                    definedIssues[i] = _issues[i];
                }
            }
            return definedIssues;
        }

        public void Add(Issue newIssue)
        {
            int nextIssueIndex = Count();
            _issues[nextIssueIndex] = newIssue;
        }

        private int Count()
        {
            int numDefinedIssues = 0;

            for (int i = 0; i < _issues.Length; i++)
            {
                if (_issues[i] != null)
                {
                    numDefinedIssues++;
                }
            }

            return numDefinedIssues;
        }

        public void EditTitle(int selectedIssueNumber, string newTitle)
        {
            if (selectedIssueNumber > 0 && !string.IsNullOrWhiteSpace(newTitle))
            {
                _issues[selectedIssueNumber - 1].Title = newTitle;
            }
            
        }

        internal void Delete(int selectedIssueNumber)
        {
            int issueIndexToRemove = selectedIssueNumber - 1;

            _issues[issueIndexToRemove] = null;

            int issuesCount = Count();

            for (int i = issueIndexToRemove; i <= issuesCount - issueIndexToRemove; i++)
            {
                _issues[i] = _issues[i + 1];
                if (_issues[i + 2] == null)
                {
                    _issues[i + 1] = null;
                }
            }
        }

        internal void MarkAsDone(int selectedIssueNumber)
        {
            int issueIndexToMark = selectedIssueNumber - 1;

            _issues[issueIndexToMark].Status = Status.Done;        }
    }
}
