// registration.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../models/User';
import { DataService } from '../services/data-service/data.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  users: User[] = [];
  formData: any = {
    name: '',
    surname: '',
    phoneNumber: '',
    weight: 0,
    height: 0,
    goalWeight: 0
  };

  loginName: string = '';

  constructor(
    private router: Router,
    private dataService: DataService,
    private snackBar: MatSnackBar
  ) { }

  onSubmit() {
    const existingUser = this.users.find(user => user.name === this.formData.name);
    if (existingUser) {
      this.snackBar.open('Username already exists', 'Close', { duration: 3000 });
    } else {
      const user: User = {
        name: this.formData.name,
        surname: this.formData.surname,
        phoneNumber: this.formData.phoneNumber,
        weight: this.formData.weight,
        height: this.formData.height,
        goalWeight: this.formData.goalWeight,
      };
      this.dataService.createUser(user).subscribe((x: User) => {
        this.snackBar.open('Registration successful', 'Close', { duration: 3000 });
        console.log('created user');
        this.router.navigate(['/home']);
      });
    }
  }

  onLogin() {
    const existingUser = this.users.find(user => user.name === this.loginName);
    if (existingUser) {
      this.snackBar.open('Login successful', 'Close', { duration: 3000 });
      this.router.navigate(['/home']);
    } else {
      this.snackBar.open('Account does not exist', 'Close', { duration: 3000 });
    }
  }

  ngOnInit() {
    this.dataService.getAllUsers().subscribe((x: User[]) => {
      this.users = x;
    });
  }
}
