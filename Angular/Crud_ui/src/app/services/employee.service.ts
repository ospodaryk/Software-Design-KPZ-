import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private url="Crew";
  constructor(private http:HttpClient) { }

  
  public GetCrewList(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${environment.apiUrl}/${this.url}`);
  }
  
  public UpdateEmployee(hero: Employee): Observable<Employee[]> {
    return this.http.put<Employee[]>(
      `${environment.apiUrl}/${this.url}`,
      hero
    );
  }

  public AddEmployee(hero: Employee): Observable<Employee[]> {
    return this.http.post<Employee[]>(
      `${environment.apiUrl}/${this.url}`,
      hero
    );
  }

  public DeleteEmployee(hero: Employee): Observable<Employee[]> {
    return this.http.delete<Employee[]>(
      `${environment.apiUrl}/${this.url}/${hero.idEmployee}`
    );
  }
}
