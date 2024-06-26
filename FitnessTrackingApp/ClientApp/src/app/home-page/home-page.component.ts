import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data-service/data.service';
import { TestModel } from '../models/TestModel';
import { User } from '../models/User';
import { Router } from '@angular/router';
import { CreateWorkout } from '../models/CreateWorkout';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent {
  selectedIndex = 0;
  user!: User;
  currentUserId!: string;
  numberOfWorkouts: number = 0;
  message: string = '';
  isLoading: boolean = true; // Variable to track loading state
  onTabChange(index: number) {
    this.selectedIndex = index;
  }
  constructor(private dataService: DataService, private router: Router) {

  }
  ngOnInit() {
    this.dataService.getUserIdByUsername(this.dataService.getUserName()).subscribe((x: any) => {
      console.log(x);
      this.user = x;
      this.currentUserId = x.id;
      this.dataService.getWorkoutsByUserId(this.currentUserId).subscribe((x: CreateWorkout[]) => {
        this.numberOfWorkouts = x.length;
        this.message = this.numberOfWorkouts <= 1 ? `You have ${this.numberOfWorkouts} workout` : `You have ${this.numberOfWorkouts} workouts`
      })
    })
  }

  logOut() {
    this.router.navigate(['']);
  }

}
