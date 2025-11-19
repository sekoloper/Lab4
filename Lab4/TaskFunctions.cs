using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    static internal class TaskFunctions
    {
        static public void PrintList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }
        }

        static public List<int> CreateList(int size)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < size; i++)
            {
                list.Add(InputValidation.InputIntegerWithValidation($"Введите значение элемента под номером {i+1}", int.MinValue, int.MaxValue));
            }
            return list;
        }

        static public bool ListHasDuplicateElements(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static public void RemoveElementFromList(List<int> list, int n)
        {
            if (list.Remove(n))
            {
                Console.WriteLine("Первое вхождение элемента с указанным значением удалено.");
            }
            else
            {
                Console.WriteLine("Элемент не найден.");
            }
        }

        static public void MusicPreferences(string[] allSongs, Dictionary<string, HashSet<string>> musicLovers)
        {
            foreach (string song in allSongs)
            {
                var musicLoversWhoLikeThisSong = new List<string>();

                foreach (var musicLover in musicLovers)
                {
                    if (musicLover.Value.Contains(song))
                    {
                        musicLoversWhoLikeThisSong.Add(musicLover.Key);
                    }
                }

                if (musicLoversWhoLikeThisSong.Count == 0)
                {
                    Console.Write($"Песня {song} не нравится никому из меломанов.\n\n");
                }
                else if (musicLoversWhoLikeThisSong.Count == musicLovers.Count)
                {
                    Console.Write($"Песня {song} нравится всем меломанам.\n\n");
                }
                else
                {
                    Console.WriteLine($"Песня {song} нравится следующим меломанам:");
                    foreach (var musicLoverWhoLikeThisSong in musicLoversWhoLikeThisSong)
                    {
                        Console.Write(musicLoverWhoLikeThisSong);
                        Console.Write("\n");
                    }
                    Console.Write("\n");
                }
            }
        }


        static public List<char> FindUniqueVowels(string text)
        {
            HashSet<char> vowels = new HashSet<char> {
            'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я'
        };

            Dictionary<char, int> vowelWordCount = new Dictionary<char, int>();

            foreach (char vowel in vowels)
            {
                vowelWordCount[vowel] = 0;
            }

            string[] words = text.Split([' ', ',', '.', '!', '?', ';', ':', '\n', '\r', '\t'],
                                      StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                HashSet<char> vowelsInCurrentWord = new HashSet<char>();

                foreach (char c in word)
                {
                    char lowerChar = char.ToLower(c);
                    if (vowels.Contains(c))
                    {
                        vowelsInCurrentWord.Add(lowerChar);
                    }
                }

                foreach (char vowel in vowelsInCurrentWord)
                {
                    vowelWordCount[vowel]++;
                }
            }

            HashSet<char> result = new HashSet<char>();
            foreach (var pair in vowelWordCount)
            {
                if (pair.Value <= 1)
                {
                    result.Add(pair.Key);
                }
            }

            List<char> sortedUniqueVowels = new List<char>();

            foreach (char vowel in vowels)
            {
                if (result.Contains(vowel))
                {
                    sortedUniqueVowels.Add(vowel);
                }
            }

            return sortedUniqueVowels;
        }

        static public void EnterResults (string filePath)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filePath);
                int n = InputValidation.InputIntegerWithValidation("Введите количество участников олимпиады: ", 1, int.MaxValue);
                writer.WriteLine(n);

                Console.WriteLine("\nВведите данные участников в формате:");
                Console.WriteLine("<Фамилия> <Имя> <Класс> <Баллы>");
                Console.WriteLine("Пример: Дроздов Олег 8 219");
                Console.WriteLine();

                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Участник {i + 1}: ");
                    string input = Console.ReadLine();

                    while (!IsValidInput(input))
                    {
                        Console.Write($"Участник {i + 1}: ");
                        input = Console.ReadLine();
                    }

                    writer.WriteLine(input);
                }

                Console.WriteLine("\nДанные успешно сохранены в файл!");
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static private bool IsValidInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Некорректные данные: пустая строка");
                return false;
            }

            string[] parts = input.Split(' ');

            if (parts.Length != 4)
            {
                Console.WriteLine("Некорректные данные: количество частей строки не 4");
                return false;
            }

            if (!int.TryParse(parts[2], out int grade) || grade < 7 || grade > 11)
            {
                Console.WriteLine("Некорректные данные: класс не в диапазоне от 7 до 11");
                return false;
            }

            if (!int.TryParse(parts[3], out int score))
            {
                Console.WriteLine("Некорректные данные: число баллов не число...");
                return false;
            }

            if (parts[0].Length > 20)
            {
                Console.WriteLine("Некорректные данные: фамилия слишком длинная, поменяйте её...");
                return false;
            }

            if (parts[1].Length > 15)
            {
                Console.WriteLine("Некорректные данные: имя слишком длинное, поменяйте его...");
                return false;
            }

            return true;
        }

        static public void WhoIsNotWinner(string filePath)
        {
            try
            {
                List<Participant> participants = new List<Participant>();
                StreamReader reader = new StreamReader(filePath);

                int n = int.Parse(reader.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(' ');

                    string lastName = parts[0];
                    string firstName = parts[1];
                    int grade = int.Parse(parts[2]);
                    int score = int.Parse(parts[3]);

                    participants.Add(new Participant(lastName, firstName, grade, score));
                }

                reader.Close();

                SortedList<int, List<Participant>> scoreGroups = new SortedList<int, List<Participant>>();

                foreach (Participant participant in participants)
                {
                    if (!scoreGroups.ContainsKey(participant.Score))
                    {
                        scoreGroups.Add(participant.Score, new List<Participant>());
                    }
                    scoreGroups[participant.Score].Add(participant);
                }

                List<int> scores = new List<int>(scoreGroups.Keys);

                for (int i = 0; i < scores.Count - 1; i++)
                {
                    for (int j = i + 1; j < scores.Count; j++)
                    {
                        if (scores[i] < scores[j])
                        {
                            int temp = scores[i];
                            scores[i] = scores[j];
                            scores[j] = temp;
                        }
                    }
                }

                List<Participant> winners = new List<Participant>();
                int totalParticipants = participants.Count;
                bool hasWinners = false;
                int winnerScore = -1;

                foreach (int score in scores)
                {
                    if (score > 200)
                    {
                        List<Participant> candidates = scoreGroups[score];
                        double percentage = (double)candidates.Count / totalParticipants * 100;

                        if (percentage <= 20)
                        {
                            winners.AddRange(candidates);
                            hasWinners = true;
                            winnerScore = score;
                            break;
                        }
                    }
                }

                if (!hasWinners)
                {
                    int maxScore = scores[0];
                    List<Participant> bestParticipants = scoreGroups[maxScore];

                    if (bestParticipants.Count > 1)
                    {
                        Console.WriteLine(bestParticipants.Count);
                    }
                    else
                    {
                        Console.WriteLine(bestParticipants[0].LastName + " " + bestParticipants[0].FirstName);
                    }
                    return;
                }

                int nextBestScore = -1;
                foreach (int score in scores)
                {
                    if (score < winnerScore)
                    {
                        nextBestScore = score;
                        break;
                    }
                }

                if (nextBestScore == -1)
                {
                    Console.WriteLine("Участники с меньшими чем у победителей баллами не найдены...");
                    return;
                }

                List<Participant> nextBestParticipants = scoreGroups[nextBestScore];

                if (nextBestParticipants.Count > 1)
                {
                    Console.WriteLine(nextBestParticipants.Count);
                }
                else
                {
                    Console.WriteLine(nextBestParticipants[0].LastName + " " + nextBestParticipants[0].FirstName);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private class Participant
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public int Grade { get; set; }
            public int Score { get; set; }

            public Participant(string lastName, string firstName, int grade, int score)
            {
                LastName = lastName;
                FirstName = firstName;
                Grade = grade;
                Score = score;
            }
        }
    }
}
