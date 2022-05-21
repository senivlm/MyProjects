using System;

namespace Vector
{
    public class SequenceInfo
    {
        public int StartIndex { get; }
        public int NumberOfSequence { get; }
        public int Number { get; }

        public SequenceInfo(int startIndex, int number, int numberOfSequence)
        {
            StartIndex = startIndex;
            Number = number;
            NumberOfSequence = numberOfSequence;
        }

        public override string ToString()
        {
            return string.Format
                ("Info about Sequence: start index: {0}, sequence count: {1}, number: {2}", StartIndex, NumberOfSequence, Number);
        }
    }
}
