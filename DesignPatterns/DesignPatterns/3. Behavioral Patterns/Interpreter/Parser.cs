using System;
using System.Collections.Generic;
using System.Globalization;

namespace DesignPatterns.Interpreter
{
    public static class Parser
    {
        public static Melody Parse(string code)
        {
            var queue = new Queue<char>(code.ToUpper());
            IEnumerable<MelodyExpression> children = Parse(queue);
            return new Melody(children);
        }

        private static IEnumerable<MelodyExpression> Parse(Queue<char> rest)
        {
            while (rest.Count != 0)
            {
                char current = rest.Dequeue();
                if (char.IsWhiteSpace(current)) continue;
                yield return Parse(current, rest);
            }
        }

        private static MelodyExpression Parse(char current, Queue<char> rest)
        {
            switch (current)
            {
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'A':
                case 'B':
                    return PareseNote(current, rest);
                case 'P':
                    return ParsePause(rest);
                case 'O':
                    return ParseOctave(current, rest);
                case 'L':
                    return ParseSetLength(current, rest);
                default:
                    throw CreateException(rest);
            }
        }

        private static MelodyExpression ParseSetLength(char current, Queue<char> rest)
        {
            Length length;
            if (!TryParseLength(current, rest, out length)) throw CreateException(rest);
            return new SetLength(length);
        }

        private static bool TryParseLength(char current, Queue<char> rest, out Length length)
        {
            string text = current + ReadNumber(rest);
            return Enum.TryParse(text, out length);
        }

        private static MelodyExpression ParseOctave(char current, Queue<char> rest)
        {
            string text = current + ReadNumber(rest);
            Octave octave;
            if (!Enum.TryParse(text, out octave)) throw CreateException(rest);
            return new SetOctave(octave);
        }

        private static Exception CreateException(Queue<char> rest)
        {
            return new NotSupportedException(
                string.Format(
                    "Unsupported symbol at '{0}'",
                    rest.Count));
        }

        private static string ReadNumber(Queue<char> rest)
        {
            string result = string.Empty;
            while (rest.Count != 0 && char.IsDigit(rest.Peek()))
            {
                char current = rest.Dequeue();
                result += current;
            }
            return result;
        }

        private static MelodyExpression ParsePause(Queue<char> rest)
        {
            MelodyExpression length = ParseLengthOptional(rest);
            return new Pause(length);
        }

        private static MelodyExpression ParseLengthOptional(Queue<char> rest)
        {
            if (rest.Count == 0) return new NullExpression(); 
            Length length;
            return
                TryParseLength('L', rest, out length)
                    ? new SetLength(length)
                    : (MelodyExpression) new NullExpression();
        }

        private static MelodyExpression PareseNote(char current, Queue<char> rest)
        {
            Tone note;
            string text = current.ToString(CultureInfo.InvariantCulture);
            if (!Enum.TryParse(text, out note)) throw CreateException(rest);

            MelodyExpression modifier = ParseModifierOptional(rest);
            MelodyExpression length = ParseLengthOptional(rest);
            MelodyExpression shortener = ParseShortenerOptional(rest);

            return new Note(note, modifier, length, shortener);
        }

        private static MelodyExpression ParseShortenerOptional(Queue<char> rest)
        {
            if (rest.Count == 0) return new NullExpression(); 
            char ch = rest.Peek();
            if (ch != '.') return new NullExpression();
            rest.Dequeue();
            return new Shortener();
        }

        private static MelodyExpression ParseModifierOptional(Queue<char> rest)
        {
            if (rest.Count == 0) return new NullExpression(); 
            char ch = rest.Peek();
            switch (ch)
            {
                case '#':
                case '+':
                    rest.Dequeue();
                    return new AccidentalModifier(Accidental.Sharp);
                case '-':
                    rest.Dequeue();
                    return new AccidentalModifier(Accidental.Flat);
                default:
                    return new NullExpression();
            }
        }
    }
}