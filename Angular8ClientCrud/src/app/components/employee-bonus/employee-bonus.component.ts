import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/services/employee.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-employee-bonus',
  templateUrl: './employee-bonus.component.html',
  styleUrls: ['./employee-bonus.component.css']
})
export class EmployeeBonusComponent implements OnInit {

  currentEmployee = null;
  message = '';

  constructor(
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.message = '';
    this.getEmployee(this.route.snapshot.paramMap.get('id'));
  }

  getEmployee(id) {
    this.employeeService.get(id)
      .subscribe(
        data => {
          this.currentEmployee = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  updateEmployee() {
    this.employeeService.update(this.currentEmployee.employeeId, this.currentEmployee)
      .subscribe(
        response => {
          console.log(response);
          this.message = 'The employee was updated successfully!';
        },
        error => {
          console.log(error);
        });
  }


}
