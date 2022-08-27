using System.Text;

namespace LIS
{
    public class Subsequence
    {
        List<string> inputList;
        List<string> comparatorList;
        List<string> outputList;
        StringBuilder outputString;

        public Subsequence() => InitiateAll();

        private void InitiateAll()
        {
            inputList = new List<string>();
            comparatorList = new List<string>();
            outputList = new List<string>();
            outputString = new StringBuilder();
        }

        public string GetLongestIncreasingSubsequence(string input)
        {
            inputList = StringSplitter(input);
            int i = 0;
            comparatorList.Add(inputList[i]);

            while (i < inputList.Count - 1)
            {
                if (int.Parse(inputList[i]) < int.Parse(inputList[i + 1]))
                {
                    i++;
                    comparatorList.Add(inputList[i]);
                }
                else
                {
                    BuildSequence();
                    i++;
                    comparatorList.Clear();
                    comparatorList.Add(inputList[i]);
                }
            }
            BuildSequence();
            return ConvertToString(outputList);
        }

        private List<string> StringSplitter(string inputString)
        {
            List<string> list = new List<string>();
            list = inputString.Split(' ').ToList();
            return list;
        }

        private void BuildSequence()
        {
            if (comparatorList.Count > outputList.Count)
            {
                outputList.Clear();
                foreach (string element in comparatorList)
                    outputList.Add(element);
            }
        }

        private string ConvertToString(List<string> outputList)
        {
            foreach (string element in outputList)
                outputString.Append(element + " ");

            return outputString.ToString().Trim();
        }
    }
}