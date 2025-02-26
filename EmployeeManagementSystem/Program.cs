class Employee {
private:
    int id;
    string name;
    string department;
    bool working;

public:
    Employee(int id, string name, string department);
    
    void terminate();
    bool isWorking() const;
    
    int getId() const;
    string getName() const;
    string getDepartment() const;
};

class EmployeeRepository {
public:
    void save(const Employee& employee);
};

class EmployeeReport {
public:
    string generateXMLReport(const Employee& employee) const;
    string generateCSVReport(const Employee& employee) const;
};
