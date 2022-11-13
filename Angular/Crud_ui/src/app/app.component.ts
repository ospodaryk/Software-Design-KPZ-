import { Component } from '@angular/core';
import { Employee } from './models/employee';
import { EmployeeService } from './services/employee.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Crud_ui';
  crew:Employee[]=[];
  employeeToEdit?: Employee;

  constructor(private employeeService:EmployeeService){}

  ngOnInit() : void{
  this.employeeService
    .GetCrewList()
    .subscribe((result:Employee[])=>(this.crew=result));
  }
 

  AddEmployee() {
    this.employeeToEdit = new Employee();
  }

  UpdateCrewList(crew: Employee[]) {
    this.crew = crew;
  }

  EditEmployee(hero: Employee) {
    this.employeeToEdit = hero;
  }
}
