import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Exercise } from '../../models/Exercise';
import { TestModel } from '../../models/TestModel';
import { User } from '../../models/User';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  createExercise(exercise: Exercise): Observable<Exercise> {
    return this.http.post<Exercise>('https://localhost:7282/api/Exercises', exercise);
  }
  getAllExercises(): Observable<Exercise[]> {
    return this.http.get<Exercise[]>('https://localhost:7282/api/Exercises');
  }
  createUser(user: User): Observable<User> {
    return this.http.post<User>('https://localhost:7282/api/Users', user);
  }
  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>('https://localhost:7282/api/Users');
  }
}
