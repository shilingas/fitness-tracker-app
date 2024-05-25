// registration.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  formData: any = {
    name: '',
    surname: '',
    phoneNumber: '',
    weight: 0,
    height: 0,
    goalWeight: 0
  };

  loginName: string = '';
  constructor(private router: Router) { }

  onSubmit() {
    this.router.navigate(['/home']);
  }

  onLogin() {
    this.router.navigate(['/home']);
  }
}
