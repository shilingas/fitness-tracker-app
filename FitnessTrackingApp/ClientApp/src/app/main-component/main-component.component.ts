import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CreateWorkout } from '../models/CreateWorkout';
import { User } from '../models/User';
import { DataService } from '../services/data-service/data.service';

@Component({
  selector: 'app-main-component',
  templateUrl: './main-component.component.html',
  styleUrls: ['./main-component.component.css']
})
export class MainComponentComponent implements OnInit {
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
      this.isLoading = false;
      this.dataService.getWorkoutsByUserId(this.currentUserId).subscribe((x: CreateWorkout[]) => {
        this.numberOfWorkouts = x.length;
        this.message = x.length <= 1 ? `You have ${this.numberOfWorkouts} workout` : `You have ${this.numberOfWorkouts} workouts`
        this.isLoading = false;
      })
      console.log('test');
    })
  }

  logOut() {
    this.router.navigate(['']);
  }

}
