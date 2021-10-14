class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        if (!name || !salary || !position || !department || salary < 0) {
            throw new Error('Invalid input!');
        }

        if (!this.departments[department]) {
            this.departments[department] = [];
        }
        const employee = {
            name,
            salary,
            position,
        };

        this.departments[department].push(employee);
        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDepartment = {
            name: '',
            averageSalary: 0,
            employees: []
        };

        for (const department of Object.keys(this.departments)) {
            let totalSalary = 0;

            for (const employee of this.departments[department]) {
                totalSalary += employee.salary;
            }

            const currentDepartmentAverageSalary = totalSalary / this.departments[department].length;

            if (currentDepartmentAverageSalary >= bestDepartment.averageSalary) {
                bestDepartment.name = department;
                bestDepartment.averageSalary = currentDepartmentAverageSalary;
                bestDepartment.employees = this.departments[department];
            }
        }
        let departmentOutput = `Best Department is: ${bestDepartment.name}\n`;
        departmentOutput += `Average salary: ${bestDepartment.averageSalary.toFixed(2)}\n`;
        const sortedEmployees = bestDepartment.employees.sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name));
        for (const employee of sortedEmployees) {
            departmentOutput += `${employee.name} ${employee.salary} ${employee.position}\n`;
        }

        return departmentOutput.trim();
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());