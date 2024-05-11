import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Exercise } from '../../models/Exercise';
import { TestModel } from '../../models/TestModel';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  createExercise(exercise: Exercise): Observable<Exercise> {
    console.log('test');
    return this.http.post<Exercise>('https://localhost:7282/api/Exercise', exercise);
  }
}
