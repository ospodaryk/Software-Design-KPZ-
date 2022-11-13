import { Component, OnInit,Input,Output, EventEmitter } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {
  @Input() employee?: Employee;
  @Output() heroesUpdated = new EventEmitter<Employee[]>();
  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
  }
  UpdateEmployee(hero: Employee) {
    this.employeeService
        .UpdateEmployee(hero)
        .subscribe((heroes: Employee[]) => this.heroesUpdated.emit(heroes));
  }

  DeleteEmployee(hero: Employee) {
    this.employeeService
        .DeleteEmployee(hero)
        .subscribe((heroes: Employee[]) => this.heroesUpdated.emit(heroes));
     }

  AddEmployee(hero: Employee) {
    this.employeeService
        .AddEmployee(hero)
        .subscribe((heroes: Employee[]) => this.heroesUpdated.emit(heroes));
    }

}
