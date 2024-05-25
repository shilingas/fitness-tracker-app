import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DataService } from '../services/data-service/data.service';
import { Exercise } from "../models/Exercise";

@Component({
  selector: 'app-exercise-creation-form',
  templateUrl: './exercise-creation-form.component.html',
  styleUrls: ['./exercise-creation-form.component.css'],
})
export class ExerciseCreationFormComponent implements OnInit {
  formGroup!: FormGroup;
  displayedColumns: string[] = ['title', 'category', 'description'];
  exercises: Exercise[] = [];

  constructor(private dataService: DataService, private snackBar: MatSnackBar) {
    this.formGroup = new FormGroup({
      title: new FormControl(''),
      category: new FormControl(''),
      description: new FormControl(''),
    })
  }

  ngOnInit(): void {
    this.loadExercises();
  }

  loadExercises(): void {
    this.dataService.getAllExercises().subscribe((exercises: Exercise[]) => {
      this.exercises = exercises;
    });
  }

  handleSubmit(form: FormGroup): void {
    const exercise: Exercise = {
      title: form.value.title,
      description: form.value.description,
      category: form.value.category,
    };
    console.log(form.value);
    this.dataService.createExercise(exercise).subscribe((x: Exercise) => {
      console.log('posted');
      this.snackBar.open('Exercise created successfully!', 'Close', {
        duration: 2000,
      });
      this.loadExercises(); // Reload the exercises after successful creation
    }, error => {
      console.error('Error creating exercise', error);
      this.snackBar.open('Failed to create exercise', 'Close', {
        duration: 2000,
      });
    });
  }
}
