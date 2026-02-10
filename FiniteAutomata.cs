using System;
using System.Collections.Generic;

namespace DataStructures.FormalLanguages
{
    public class AutomataState
    {
        public string Name { get; set; }

        public AutomataState(string name)
        {
            Name = name;
        }
    }

    public class Transition
    {
        public AutomataState From { get; set; }
        public AutomataState To { get; set; }
        public string Trigger { get; set; }

        public Transition(AutomataState from, AutomataState to, string trigger)
        {
            From = from;
            To = to;
            Trigger = trigger;
        }
    }

    public class FiniteAutomata
    {
        // ... (ваш существующий код)

        /// <summary>
        /// Создает конечный автомат для языка L1 = (ab)*
        /// </summary>
        public static FiniteAutomata CreateForL1()
        {
            // Создаем состояния
            var stateA = new AutomataState("A"); // начальное и конечное
            var stateB = new AutomataState("B");
            var stateC = new AutomataState("C"); // состояние-ловушка

            // Создаем автомат
            var automata = new FiniteAutomata
            {
                Alphabet = new List<string> { "a", "b" },
                AutomataStates = new List<AutomataState> { stateA, stateB, stateC },
                StartState = stateA,
                EndStates = new List<AutomataState> { stateA },
                Transitions = new List<Transition>
                {
                    // Корректные переходы
                    new Transition(stateA, stateB, "a"),  // A --a--> B
                    new Transition(stateB, stateA, "b"),  // B --b--> A
                    
                    // Переходы в состояние-ловушку
                    new Transition(stateA, stateC, "b"),  // A --b--> C (неправильный символ)
                    new Transition(stateB, stateC, "a"),  // B --a--> C (неправильный символ)
                    
                    // Переходы из состояния-ловушки (зацикливание)
                    new Transition(stateC, stateC, "a"),
                    new Transition(stateC, stateC, "b")
                }
            };

            return automata;
        }

        /// <summary>
        /// Проверить цепочку на принадлежность языку L1 = (ab)*
        /// </summary>
        public static bool CheckL1(string input)
        {
            var automata = CreateForL1();
            return automata.CheckString(input);
        }
    }
}

/*
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.FormalLanguages
{
    public class AutomataState
    {
        public string Name { get; set; }
        
        public AutomataState(string name)
        {
            Name = name;
        }
    }

    public class Transition
    {
        public AutomataState From { get; set; }
        public AutomataState To { get; set; }
        public string Trigger { get; set; }
        
        public Transition(AutomataState from, AutomataState to, string trigger)
        {
            From = from;
            To = to;
            Trigger = trigger;
        }
    }

    public class FiniteAutomata
    {
        public List<string> Alphabet { get; set; } = [];
        public List<AutomataState> AutomataStates { get; set; } = [];
        public required AutomataState StartState { get; set; }
        public required List<AutomataState> EndStates { get; set; }
        public List<Transition> Transitions { get; set; } = [];

        public bool CheckString(string check)
        {
            AutomataState currentState = StartState;
            int index = 0;
            char currentChar = check[index];
            AutomataState? nextState = GetTransition(currentChar, currentState);
            
            while (nextState != null && index < check.Length-1)
            {
                currentState = nextState;
                index++;
                currentChar = check[index];
                nextState = GetTransition(currentChar, currentState);
            }

            currentState = nextState;

            if (index < check.Length - 1) return false;
            if (EndStates.Contains(currentState))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private AutomataState? GetTransition(char currentChar, AutomataState currentState)
        {
            foreach (var transition in Transitions)
            {
                if(transition.From == currentState && transition.Trigger == Convert.ToString(currentChar))
                {
                    return transition.To;
                }
            }
            return null;
        }

        public static FiniteAutomata CreateForL1()
        {
            var stateA = new AutomataState("A");
            var stateB = new AutomataState("B");
            var stateC = new AutomataState("C");
            
            var automata = new FiniteAutomata
            {
                Alphabet = new List<string> { "a", "b" },
                AutomataStates = new List<AutomataState> { stateA, stateB, stateC },
                StartState = stateA,
                EndStates = new List<AutomataState> { stateA },
                Transitions = new List<Transition>
                {
                    new Transition(stateA, stateB, "a"),
                    new Transition(stateB, stateA, "b"),
                    new Transition(stateA, stateC, "b"),
                    new Transition(stateB, stateC, "a"),
                    new Transition(stateC, stateC, "a"),
                    new Transition(stateC, stateC, "b")
                }
            };
            
            return automata;
        }
        
        public static bool CheckL1(string input)
        {
            var automata = CreateForL1();
            return automata.CheckString(input);
        }
        
        public static bool CheckL1Directly(string input)
        {
            if (string.IsNullOrEmpty(input)) return true;
            if (input.Length % 2 != 0) return false;
            
            for (int i = 0; i < input.Length; i += 2)
            {
                if (input[i] != 'a' || input[i + 1] != 'b')
                    return false;
            }
            
            return true;
        }

        public static FiniteAutomata CreateForL2()
        {
            var stateA = new AutomataState("A");
            var stateB = new AutomataState("B");
            var stateC = new AutomataState("C");
            var stateD = new AutomataState("D");
            var stateE = new AutomataState("E");
            var stateF = new AutomataState("F");
            var stateG = new AutomataState("G");
            
            var automata = new FiniteAutomata
            {
                Alphabet = new List<string> { "a", "b", "c" },
                AutomataStates = new List<AutomataState> { 
                    stateA, stateB, stateC, stateD, stateE, stateF, stateG 
                },
                StartState = stateA,
                EndStates = new List<AutomataState> { stateE, stateF },
                Transitions = new List<Transition>
                {
                    new Transition(stateA, stateB, "a"),
                    new Transition(stateA, stateG, "b"),
                    new Transition(stateA, stateC, "c"),
                    
                    new Transition(stateB, stateG, "a"),
                    new Transition(stateB, stateA, "b"),
                    new Transition(stateB, stateG, "c"),
                    
                    new Transition(stateC, stateD, "a"),
                    new Transition(stateC, stateE, "b"),
                    new Transition(stateC, stateG, "c"),
                    
                    new Transition(stateD, stateC, "a"),
                    new Transition(stateD, stateG, "b"),
                    new Transition(stateD, stateG, "c"),
                    
                    new Transition(stateE, stateF, "a"),
                    new Transition(stateE, stateG, "b"),
                    new Transition(stateE, stateG, "c"),
                    
                    new Transition(stateF, stateF, "a"),
                    new Transition(stateF, stateG, "b"),
                    new Transition(stateF, stateG, "c"),
                    
                    new Transition(stateG, stateG, "a"),
                    new Transition(stateG, stateG, "b"),
                    new Transition(stateG, stateG, "c")
                }
            };
            
            return automata;
        }
        
        public static bool CheckL2(string input)
        {
            var automata = CreateForL2();
            return automata.CheckString(input);
        }
        
        public static bool CheckL2Directly(string input)
        {
            int i = 0;
            int n = input.Length;
            
            while (i + 1 < n && input[i] == 'a' && input[i + 1] == 'b')
            {
                i += 2;
            }
            
            if (i >= n || input[i] != 'c') return false;
            i++;
            
            while (i + 1 < n && input[i] == 'b' && input[i + 1] == 'a')
            {
                i += 2;
            }
            
            if (i >= n || input[i] != 'b') return false;
            i++;
            
            while (i < n && input[i] == 'a')
            {
                i++;
            }
            
            return i == n;
        }

        public static FiniteAutomata CreateForL3()
        {
            var stateA = new AutomataState("A");
            var stateB = new AutomataState("B");
            var stateC = new AutomataState("C");
            var stateD = new AutomataState("D");
            var stateE = new AutomataState("E");
            var stateF = new AutomataState("F");
            var stateG = new AutomataState("G");
            var stateH = new AutomataState("H");
            
            var automata = new FiniteAutomata
            {
                Alphabet = new List<string> { "a", "b", "c" },
                AutomataStates = new List<AutomataState> { 
                    stateA, stateB, stateC, stateD, stateE, stateF, stateG, stateH 
                },
                StartState = stateA,
                EndStates = new List<AutomataState> { stateH },
                Transitions = new List<Transition>
                {
                    new Transition(stateA, stateA, "a"),
                    new Transition(stateA, stateA, "b"),
                    new Transition(stateA, stateB, "c"),
                    
                    new Transition(stateB, stateA, "a"),
                    new Transition(stateB, stateC, "b"),
                    new Transition(stateB, stateA, "c"),
                    
                    new Transition(stateC, stateA, "a"),
                    new Transition(stateC, stateA, "b"),
                    new Transition(stateC, stateD, "c"),
                    
                    new Transition(stateD, stateA, "a"),
                    new Transition(stateD, stateE, "b"),
                    new Transition(stateD, stateA, "c"),
                    
                    new Transition(stateE, stateF, "a"),
                    new Transition(stateE, stateG, "b"),
                    new Transition(stateE, stateA, "c"),
                    
                    new Transition(stateF, stateA, "a"),
                    new Transition(stateF, stateH, "b"),
                    new Transition(stateF, stateA, "c"),
                    
                    new Transition(stateG, stateH, "a"),
                    new Transition(stateG, stateA, "b"),
                    new Transition(stateG, stateA, "c"),
                    
                    new Transition(stateH, stateA, "a"),
                    new Transition(stateH, stateA, "b"),
                    new Transition(stateH, stateA, "c")
                }
            };
            
            return automata;
        }
        
        public static bool CheckL3(string input)
        {
            var automata = CreateForL3();
            return automata.CheckString(input);
        }
        
        public static bool CheckL3Directly(string input)
        {
            int n = input.Length;
            
            if (n < 6) return false;
            
            string lastTwo = input.Substring(n - 2);
            if (lastTwo != "ab" && lastTwo != "ba") return false;
            
            int cbcbIndex = input.IndexOf("cbcb");
            if (cbcbIndex == -1) return false;
            
            if (cbcbIndex > n - 6) return false;
            
            for (int i = 0; i < cbcbIndex; i++)
            {
                if (input[i] != 'a' && input[i] != 'b') return false;
            }
            
            if (cbcbIndex + 4 != n - 2) return false;
            
            return true;
        }
        
        public static bool CheckL3StateMachine(string input)
        {
            int state = 0;
            
            foreach (char ch in input)
            {
                switch (state)
                {
                    case 0:
                        if (ch == 'a' || ch == 'b') state = 0;
                        else if (ch == 'c') state = 1;
                        else return false;
                        break;
                        
                    case 1:
                        if (ch == 'b') state = 2;
                        else return false;
                        break;
                        
                    case 2:
                        if (ch == 'c') state = 3;
                        else return false;
                        break;
                        
                    case 3:
                        if (ch == 'b') state = 4;
                        else return false;
                        break;
                        
                    case 4:
                        if (ch == 'a') state = 5;
                        else if (ch == 'b') state = 6;
                        else return false;
                        break;
                        
                    case 5:
                        if (ch == 'b') state = 7;
                        else return false;
                        break;
                        
                    case 6:
                        if (ch == 'a') state = 7;
                        else return false;
                        break;
                        
                    case 7:
                        return false;
                        
                    default:
                        return false;
                }
            }
            
            return state == 7;
        }
    }
}
 */
