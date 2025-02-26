Assignment -3 Functions Clean Code

Overview:
This console application allows users to search for customers from an in-memory database based on three search criteria: Country, Company Name, and Contact Name. Refactored code ensuring meaningful names, small functions, encapsulated error handling.

Meaningful Names:
- The code uses self-explanatory function and variable names that clearly define their purpose.
- Functions like GetSearchType(), GetSearchKeyword(), and DisplayResults() indicate their responsibilities.

Small, Focused Functions:
- Each function has a single, well-defined responsibility, promoting the Single Responsibility Principle (SRP).
- The Main() function is short and acts as a coordinator, calling other well-structured functions.
- Input handling, searching, result display, and exception handling are modularized, ensuring clean separation of concerns.
- Uses a switch expression in SearchCustomers() for easy extensibility.

Exception Handling:
- Centralized error handling using a dedicated HandleException() function that categorizes and provides meaningful error messages.
- SafeExecute<T>() abstracts try-catch logic, for consistent failure handling and reducing code duplication.
- Fallback values are used to prevent crashes, ensuring the application runs smoothly even in case of failures.

Summary of Clean Code Best Practices Followed:
- Meaningful Names: Clearly defined functions and variables avoid ambiguity.
- Small Functions: Each function performs one task, keeping code readable and maintainable.
- Error Handling: Centralized exception handling improves reliability.
- DRY Principle: No duplicated logic due to SafeExecute<T>().
- Separation of Concerns: Business logic, UI handling, and data management are distinctly separated.
- Open/Closed Principle: Easily extendable search functionality without modifying existing code.
- Fail Fast & Gracefully: Fallback values prevent crashes, ensuring smooth user experience.
