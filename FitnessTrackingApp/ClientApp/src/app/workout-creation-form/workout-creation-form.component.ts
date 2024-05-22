import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data-service/data.service';
import { Exercise } from '../models/Exercise';
@Component({
  selector: 'app-workout-creation-form',
  templateUrl: './workout-creation-form.component.html',
  styleUrls: ['./workout-creation-form.component.css']
})
export class WorkoutCreationFormComponent implements OnInit {

  constructor(private dataService: DataService) { }
  exercises!: Exercise[];
  ngOnInit(): void {
    this.dataService.getAllExercises().subscribe((x: Exercise[]) => {
      this.exercises = x;
      console.log(this.exercises);
    })
  }

}
