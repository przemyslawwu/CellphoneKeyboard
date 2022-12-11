using System;
namespace keyboard
{
    public class keyboard
    {
        private string? userinput;         //input from user;
        public char[]? uInputArray;        //input from user as a char array;
        public int InputLength;            //amount of input letters;
        public int Ascii = 065;            //ascii code, starts from 'A';
        public int counter = 0;            //counter that counts the order of letters;
        public int KeyboardNumber1 = 2;    //
        public int KeyboardNumber2 = 22;   // KeyboardNumber(amount of numbers);
        public int KeyboardNumber3 = 222;  // Indicates how many times you have to press a button to get a letter;
        public int KeyboardNumber4 = 7777; // <-- This variable defaults to '7777' because button 7 is the first to have 4 letters in it
        private Dictionary<char, int> dictionary = new Dictionary<char, int>(); //alphabet dictionary

        public void Hello()
        {
            Console.Write("Type the word. \n" +
                "The program will display how many times what key on the old phone's keypad you need to press to get the given word: \n");
            Console.WriteLine("\n -----------------\n" +
                   "|  1  |  2  |  3  |\n" +
                   "|     | ABC | DEF |\n" +
                   "|  4  |  5  |  6  |\n" +
                   "| GHI | JKL | MNO |\n" +
                   "|  7  |  8  |   9 |\n" +
                   "| PQRS| TUV |WXYZ |\n");
            Console.Write(">");
        }

        public void SetUserInput(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsLetter(c))  //checking if input's char is not a letter;
                {
                    Console.Write("Incorrect input.");
                    Environment.Exit(1);
                }
            };
            userinput = text.ToUpper();      //converting input do uppercase to make it easier to add/sub ascii values
            InputLength = userinput.Length;  
            uInputArray = userinput.ToArray();
            Console.Write("The letters have been changed to uppercase to facilitate operations on ascii values: " + userinput);
        }


        public void AddToDictionary(int value)
        {                                       //adding a value with specific key to alphabet dictionary,
            dictionary.Add((char)Ascii, value); //value is the amount of button presses
        }                                       


        public void ReplaceDictionaryValue(int value)   
        {
            switch (value) //checking which value has to be replaced in the alphabet dictionary, 
            {              //used to put proper amount of specific button presses  
                case 1:
                    dictionary[(char)Ascii] = KeyboardNumber1; //puts one button press;
                    break;
                case 2:
                    dictionary[(char)Ascii] = KeyboardNumber2; //puts two button presses;
                    break;
                case 3:
                    dictionary[(char)Ascii] = KeyboardNumber3; //...and so on;
                    break;
                case 4:
                    dictionary[(char)Ascii] = KeyboardNumber4;
                    break;
            }
        }

        public void IncreaseKeyboardValue(int value)
        {               
            switch (value)  //checking which variable that stores the number of button presses has to be increased,
            {               //so that the proper values are added to the lettered key in the dictionary
                case 1:
                    KeyboardNumber1 += 1;
                    break;
                case 2:
                    KeyboardNumber2 += 11;
                    break;
                case 3:
                    KeyboardNumber3 += 111;
                    break;
                case 4:
                    KeyboardNumber4 += 2222; //incrementation by 2, because the '9' button is the last button 
                    break;                   //that has 4 letters (default value of this var is 7777)
            }
        }

        public void ProcessingDictionary()  //entering letters into the dictionary 
        {                                   //and the amount of specific button presses as values
            for (int i = 0; i < 26; i++)    
            {
                AddToDictionary(KeyboardNumber1);
                if (counter == 2 || counter == 5 || counter == 8 || counter == 11 || counter == 14 ||
                counter == 21) //if the letter needs 3 pushes of specific button//third press of the button;
                {
                    ReplaceDictionaryValue(3); //replacing values of third letter key with amount of 3 presses;
                    IncreaseKeyboardValue(1);  //increasing KeyboardValue1 to use incremented value in the next loop;
                    IncreaseKeyboardValue(3);  //increasing KeyboardValue3 to use incremented value in the next loop;
                    Ascii -= 1;                //decrementation of ascii value to replace value of secound letter;
                    ReplaceDictionaryValue(2); 
                    IncreaseKeyboardValue(2);  
                    Ascii += 1;                //incrementation so that the loop outside the condition;
                                               //does the correct incrementation to move on to the next letter;
                }
                if (counter == 18 || counter == 25) //if the letter needs 4 pushes of specific button
                {
                    ReplaceDictionaryValue(4); //replacing values of fourth letter key with amount of 4 presses/fourh press of the button;
                    IncreaseKeyboardValue(1);
                    IncreaseKeyboardValue(4);
                    Ascii -= 1;
                    ReplaceDictionaryValue(3);
                    IncreaseKeyboardValue(3);
                    Ascii -= 1;
                    ReplaceDictionaryValue(2);
                    IncreaseKeyboardValue(2);
                    Ascii += 2;
                }
                Ascii++;
                counter++;
            }
        }

        public void FinalOutput()
        {
            Console.Write("\nKEYS: |");
            foreach (var keyValuePair in dictionary)  //printing out how many times you have to press a particular key
            {                                         //to get a particular letter
                Console.Write(keyValuePair.Key);
                Console.Write(keyValuePair.Value);
                Console.Write("|");
            }

            Console.Write("\n## Result: \n - ");
            for (int i = 0; i < InputLength; i++)
            {
                Console.Write(dictionary[uInputArray[i]].GetHashCode()); //printing out the values of the keys represented by each letter of the word
            }
        }
    }
}

