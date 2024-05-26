import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DataService } from '../services/data-service/data.service';
import { Exercise } from '../models/Exercise';
import { UserExercise } from '../models/UserExercise';
import { CreateWorkout } from '../models/CreateWorkout';

@Component({
  selector: 'app-workout-creation-form',
  templateUrl: './workout-creation-form.component.html',
  styleUrls: ['./workout-creation-form.component.css']
})
export class WorkoutCreationFormComponent implements OnInit {
  formGroup!: FormGroup;
  exercises: Exercise[] = [];
  currentWorkouts: CreateWorkout[] = [];
  userId!: string;
  displayedColumns: string[] = ['name', 'actions'];

  constructor(private formBuilder: FormBuilder, private dataService: DataService) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      workoutName: ['']
    });

    this.dataService.getUserIdByUsername(this.dataService.getUserName()).subscribe((x: any) => {
      this.userId = x.id;
      console.log(this.userId);

      this.dataService.getWorkoutsByUserId(this.userId).subscribe((workouts: CreateWorkout[]) => {
        this.currentWorkouts = workouts;
        console.log(this.currentWorkouts);
      });
    });

    this.dataService.getAllExercises().subscribe((exercises: Exercise[]) => {
      this.exercises = exercises;
      console.log(this.exercises);
    });



  }


  handleWorkoutNameSubmit() {
    const workout: CreateWorkout = {
      name: this.formGroup.value.workoutName,
      userId: this.userId,
    };

    this.dataService.createWorkout(workout).subscribe((x: CreateWorkout) => {
      console.log('created');
      this.dataService.getWorkoutsByUserId(this.userId).subscribe((workouts: CreateWorkout[]) => {
        this.currentWorkouts = workouts;
        console.log(this.currentWorkouts);
      });
    });
  }


}
