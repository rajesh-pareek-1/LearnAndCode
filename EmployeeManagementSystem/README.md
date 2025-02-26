Assignment-5 Functions Clean Code

Issues with the Original Code:
The initial version of the `Employee` class had several clean code violations:

1. Violation of the Single Responsibility Principle (SRP)
   - The class was responsible for employee management, persistence (database saving), and report generation all in one place.  
   - This makes it difficult to modify, test, or extend each responsibility independently.  

2. Poor Naming Conventions 
   - Method names like `saveEmployeeToDatabase()` and `printEmployeeDetailReportXML()` were unnecessarily long.  
   - `working` was named ambiguously, and `terminateEmployee()` could be simplified.  

3. Violation of Open/Closed Principle (OCP)  
   - If we wanted to introduce a new report format (e.g., JSON), we would have to modify the existing class, violating OCP.  

4. Tightly Coupled Code
   - The `Employee` class handled both data management and persistence, making it tightly coupled with the database.  
   - This means any change in how we store employees would require modifying the `Employee` class itself.  

5. Low Reusability (DRY Violation)
   - The report generation logic was mixed inside the employee class. If another part of the system needed similar reports, we would need to duplicate code or extract it later.  

## After Refactoring
To fix these issues, I applied clean code principles from Chapters 1-3:

1. Separation of Concerns (SRP) → Extracted Responsibilities into Separate Classes* 
   - `Employee` now only deals with an employee's data and status.  
   - `EmployeeRepository` handles database storage separately.  
   - `EmployeeReport` manages report generation in different formats.  

2. Improved Naming for Clarity and Readability
   - `terminateEmployee()` → `terminate()` (clear and concise).  
   - `saveEmployeeToDatabase()` → `save()` in `EmployeeRepository`.  
   - `printEmployeeDetailReportXML()` → `generateXMLReport()`.  

3. Applied Open/Closed Principle (OCP) for Extendability
   - We can easily add new report formats (e.g., JSON) by extending `EmployeeReport` without modifying the Employee class.  

4. Reduced Coupling → Improved Maintainability
   - `Employee` does not know how it's stored in the database.  
   - If we switch from a SQL database to a NoSQL one, we only need to modify `EmployeeRepository`, not the Employee class.  

5. Eliminated Redundancy (DRY)
   - Report generation is now centralized in `EmployeeReport`, ensuring no duplicate code when formatting reports.  