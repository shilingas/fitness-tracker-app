import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DataService } from '../services/data-service/data.service';
import { Exercise } from '../models/Exercise';
import { UserExercise } from '../models/UserExercise';
import { CreateWorkout } from '../models/CreateWorkout';
import { MatSnackBar } from '@angular/material/snack-bar';

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
  editingWorkoutId: string | null = null;
  isLoading: boolean = true; // Variable to track loading state
  constructor(private formBuilder: FormBuilder, private dataService: DataService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      workoutName: ['']
    });

    this.dataService.getUserIdByUsername(this.dataService.getUserName()).subscribe((x: any) => {
      this.userId = x?.id;
      if (this.userId) {
        this.loadWorkouts();
      }
    });

    this.dataService.getAllExercises().subscribe((exercises: Exercise[]) => {
      this.exercises = exercises;
      console.log(this.exercises);
    });
  }

  loadWorkouts() {
    this.dataService.getWorkoutsByUserId(this.userId).subscribe((workouts: CreateWorkout[]) => {
      this.currentWorkouts = workouts;
      console.log(this.currentWorkouts);
      this.isLoading = false;
    });
  }

  enableEdit(workoutId: string) {
    this.editingWorkoutId = workoutId;
  }

  updateWorkoutName(workout: CreateWorkout) {
    if (this.editingWorkoutId && workout.name) {
      this.dataService.updateWorkout(this.editingWorkoutId, workout).subscribe((updatedWorkout: CreateWorkout) => {
        console.log('Workout updated:', updatedWorkout);
        this.snackBar.open('Workout is updated!', 'Close', {
          duration: 2000,
        });
        this.loadWorkouts();
        this.cancelEdit();
      });
    }
  }

  cancelEdit() {
    this.editingWorkoutId = null;
  }

  handleDelete(id: string) {
    this.dataService.deleteWorkout(id).subscribe(() => {
      console.log('Workout deleted');
      this.snackBar.open('Workout is deleted!', 'Close', {
        duration: 2000,
      });
      this.loadWorkouts();
    });
  }

  handleWorkoutNameSubmit() {
    const workout: CreateWorkout = {
      name: this.formGroup.value.workoutName,
      userId: this.userId,
    };

    this.dataService.createWorkout(workout).subscribe((x: CreateWorkout) => {
      console.log('Workout created:', x);
      this.loadWorkouts();
    });
  }
}
