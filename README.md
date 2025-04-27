# WordFilter

A C# application that takes multiple text filters and applies them on any given string. The application:
 - Reads from a text file
 - Creates and applies the following 3 filters:
   - Filter1: filter out all the words that contain a vowel in the middle of the word - the centre 1 or 2 letters ("clean" middle is 'e', "what" middle is 'h', "currently" middle is 'e' and should be filtered, "the", "rather" should not be)
   - Filter2: filter out words that have length less than 3
   - Filter3: filter out words that have the letter 't'
 - After all filters have completed displays the resulting text in the console
