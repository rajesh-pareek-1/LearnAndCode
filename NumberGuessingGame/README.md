Assignment-1 Functions Clean Code

Issues with the Previous Code (Python Version):

1. Poor Function Naming:

The function fun() is ambiguously named and does not clearly express its intent. It checks if a string represents a number between 1 and 100, but the name does not communicate this.

2. Global Variable Dependence:

The function fun() references s, but s is not explicitly passed as a parameter, causing issues with debugging.

3. Violation of the Single Responsibility Principle (SRP):

The main() function handles multiple concerns: input validation, game logic, user interaction, and tracking attempts. Each responsibility should be isolated to improve maintainability.

4. Poor Error Handling and Input Validation:

The code does not handle invalid input effectively.

Instead of prompting users correctly, it incorrectly assumes the next input will always be valid. Converting input without checking leads to potential errors.

Lack of Code Reusability:

5. Validation logic is duplicated.

Instead of reusing a function to handle valid input retrieval, the game keeps checking inside while loops with repeated input() calls.

Improvements in the Refactored Code (C# Version):

1. Meaningful Function Names:

PlayGame() clearly defines the game's execution flow.

GetValidGuess() explicitly states its purpose: to retrieve and validate user input.

2. Separation of Concerns:

PlayGame() handles the game logic and flow.

GetValidGuess() ensures input is valid before it is used.

3. Avoiding Global Variables:

Every function operates on locally scoped variables, reducing side effects.

4. Proper Input Validation:

GetValidGuess() continuously prompts the user until a valid number is entered.

Uses int.TryParse() to safely handle user input, preventing crashes due to invalid entries.