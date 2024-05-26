import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Exercise } from '../models/Exercise';
import { User } from '../models/User';
import { UserExercise } from '../models/UserExercise';
import { DataService } from '../services/data-service/data.service';
import { forkJoin } from 'rxjs';
@Component({
  selector: 'app-workout-details',
  templateUrl: './workout-details.component.html',
  styleUrls: ['./workout-details.component.css']
})
export class WorkoutDetailsComponent implements OnInit {
  formGroup!: FormGroup;
  userId!: string;
  exercises: Exercise[] = [];
  currentExerciseId!: string;
  workoutId!: string;
  exerciseDetails: { name: string; maxReps: number; maxWeight: number; }[] = [];
  currentExercises!: UserExercise[];
  displayedColumns: string[] = ['name', 'maxReps', 'maxWeight'];
  isLoading: boolean = true; // Variable to track loading state
  constructor(private formBuilder: FormBuilder, private dataService: DataService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      exerciseName: '',
      maxWeight: 0,
      maxReps: 0
    });

    this.dataService.getUserIdByUsername(this.dataService.getUserName()).subscribe((x: any) => {
      console.log('x', x.id);

    })
    this.dataService.getAllExercises().subscribe((exercises: Exercise[]) => {
      this.exercises = exercises;
      console.log(this.exercises);
    });
    this.route.paramMap.subscribe(params => {
      this.workoutId = params.get('id')!;
      console.log(this.workoutId);
    });
    this.dataService.getWorkoutsExercises(this.workoutId).subscribe((ex: UserExercise[]) => {
      this.currentExercises = ex;
      console.log(this.currentExercises);
    })
    this.loadUserExercises();
  }

  loadAllUserExercises() {
    this.dataService.getWorkoutsExercises(this.workoutId).subscribe((ex: UserExercise[]) => {
      this.currentExercises = ex;
      console.log(this.currentExercises);
    })
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
    };

    this.dataService.createUserExercise(userExercise).subscribe((x: any) => {
      console.log('created user exercise');
      this.currentExerciseId = x.id;


      console.log(this.currentExerciseId, this.workoutId);
      this.dataService.addUserExerciseToWorkout(this.currentExerciseId, this.workoutId, userExercise).subscribe((y: UserExercise) => {
        console.log('added exercise to workout');
        this.loadAllUserExercises();
        this.loadUserExercises();
      });
    })
  }

  loadUserExercises() {
    this.dataService.getWorkoutsExercises(this.workoutId).subscribe((ex: UserExercise[]) => {
      this.currentExercises = ex;
      console.log('current exercises', this.currentExercises);

      const exerciseDetails$ = this.currentExercises.map(exercise =>
        this.dataService.getExerciseById(exercise.exerciseId)
      );

      forkJoin(exerciseDetails$).subscribe((details: Exercise[]) => {
        this.exerciseDetails = details.map((detail, index) => ({
          name: detail.title,
          maxReps: this.currentExercises[index].maxReps,
          maxWeight: this.currentExercises[index].maxWeight
        }));
        console.log('exercise details', this.exerciseDetails);
        this.isLoading = false;
      });
    });
  }
}
