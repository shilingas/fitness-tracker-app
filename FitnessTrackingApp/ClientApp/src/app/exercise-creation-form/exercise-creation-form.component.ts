import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DataService } from '../services/data-service/data.service';
import { Exercise } from "../models/Exercise";
@Component({
  selector: 'app-exercise-creation-form',
  templateUrl: './exercise-creation-form.component.html',
  styleUrls: ['./exercise-creation-form.component.css']
})
export class ExerciseCreationFormComponent implements OnInit {
  formGroup!: FormGroup;
  constructor(private dataService: DataService) {
    this.formGroup = new FormGroup({
       title: new FormControl(''),
       description: new FormControl(''),
       imageData: new FormControl(''),
     })
  }

  ngOnInit(): void {
  }
  handleSubmit(form: FormGroup): void {
    const exercise: Exercise = {
      title: form.value.title,
      description: form.value.description,
      imageData: form.value.imageData,
    };
    console.log(form.value);
    this.dataService.createExercise(exercise).subscribe((x: Exercise) => {
      console.log('posted');
    })
  }
}
