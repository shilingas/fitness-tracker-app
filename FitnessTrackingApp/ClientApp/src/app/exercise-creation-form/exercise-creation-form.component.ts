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
  displayedColumns: string[] = ['title', 'category', 'description', 'actions'];
  exercises: Exercise[] = [];
  editedExercise: Exercise | null = null;
  editedExerciseId: string | null = null;

  constructor(private dataService: DataService, private snackBar: MatSnackBar) {
    this.formGroup = new FormGroup({
      title: new FormControl(''),
      category: new FormControl(''),
      description: new FormControl(''),
    });
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
    this.dataService.createExercise(exercise).subscribe((x: Exercise) => {
      this.snackBar.open('Exercise created successfully!', 'Close', {
        duration: 2000,
      });
      this.loadExercises();
    }, error => {
      this.snackBar.open('Failed to create exercise', 'Close', {
        duration: 2000,
      });
    });
  }

  startEditing(exercise: Exercise, exerciseId: string): void {
    this.editedExercise = { ...exercise };
    this.editedExerciseId = exerciseId;
  }

  cancelEditing(): void {
    this.editedExercise = null;
    this.editedExerciseId = null;
  }

  saveExercise(): void {
    if (this.editedExercise && this.editedExerciseId) {
      this.dataService.updateExercise(this.editedExerciseId, this.editedExercise).subscribe(updatedExercise => {
        this.snackBar.open('Exercise updated successfully!', 'Close', {
          duration: 2000,
        });
        this.loadExercises();
        this.editedExercise = null;
        this.editedExerciseId = null;
      }, error => {
        this.snackBar.open('Failed to update exercise', 'Close', {
          duration: 2000,
        });
      });
    }
  }
}
