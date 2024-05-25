import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DataService } from '../services/data-service/data.service';
import { Exercise } from '../models/Exercise';
import { FormControl } from '@angular/forms';
import { User } from ".././models/User";
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
  userId!: string;
  constructor(private formBuilder: FormBuilder, private dataService: DataService) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      exerciseName: '',
      maxWeight: 0,
      maxReps: 0
    });
    this.dataService.getUserIdByUsername(this.dataService.getUserName()).subscribe((x: any) => {
      this.userId = x.id;
    });
    this.dataService.getAllExercises().subscribe((exercises: Exercise[]) => {
      this.exercises = exercises;
      console.log(this.exercises)
    });
  }

  handleSubmit() {
    const formValues = this.formGroup.value;
    const selectedExerciseName = formValues.exerciseName;

    const selectedExercise: any = this.exercises.find(exercise => exercise.title === selectedExerciseName);
    const userExercise: UserExercise = {
      exerciseId: selectedExercise.id,
      userId: this.userId,
      maxWeight: formValues.maxWeight,
      maxReps: formValues.maxReps,
    }
    this.dataService.createUserExercise(userExercise).subscribe((x: UserExercise) => {
      console.log('created user exercise');
    })
  }

  handleWorkoutNameSubmit(workoutName: string) {
    const workout: CreateWorkout = {
      name: workoutName,
    };

    this.dataService.createWorkout(workout).subscribe((x: CreateWorkout) => {
      console.log('created');
    })
  }

}
