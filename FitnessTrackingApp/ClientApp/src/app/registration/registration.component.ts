import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../models/User';
import { DataService } from '../services/data-service/data.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
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
    private snackBar: MatSnackBar,
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
        heigth: this.formData.heigth,
        goalWeight: this.formData.goalWeight,
      };
      console.log(user);
      this.dataService.setUserName(user.name); // Save the username
      this.dataService.createUser(user).subscribe((x: User) => {
        this.snackBar.open('Registration successful', 'Close', { duration: 3000 });
        console.log('created user');
        this.resetFormData();
        this.router.navigate(['/home']);
      });
    }
  }

  onLogin() {
    const existingUser = this.users.find(user => user.name === this.loginName);
    this.dataService.setUserName(this.loginName);
    if (existingUser) {
      this.snackBar.open('Login successful', 'Close', { duration: 3000 });
      this.loginName = ''; // Clear the loginName field after successful login
      this.router.navigate(['/home']);
    } else {
      this.snackBar.open('Account does not exist', 'Close', { duration: 3000 });
    }
  }

  ngOnInit() {
    this.dataService.getAllUsers().subscribe((x: User[]) => {
      this.users = x;
    });
    // Load the saved loginName from the data service
    this.loginName = this.dataService.getUserName();
    this.loginName = '';
  }

  resetFormData() {
    this.formData = {
      name: '',
      surname: '',
      phoneNumber: '',
      weight: 0,
      height: 0,
      goalWeight: 0
    };
  }
}
