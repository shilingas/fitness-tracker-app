import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { CreateWorkout } from '../../models/CreateWorkout';
import { Exercise } from '../../models/Exercise';
import { TestModel } from '../../models/TestModel';
import { User } from '../../models/User';
import { UserExercise } from '../../models/UserExercise';

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
    console.log('done');
  }
  createUserExercise(userExercise: UserExercise) {
    return this.http.post<UserExercise>('https://localhost:7282/api/UserExcercises', userExercise);
  }

  getUserIdByUsername(username: string): Observable<User | undefined> {
    return this.getAllUsers().pipe(
      map((users: User[]) => {
        const user = users.find(u => u.name === username);
        return user;
      })
    );
  }
  private userName: string = '';

  setUserName(name: string) {
    this.userName = name;
  }

  getUserName(): string {
    return this.userName;
  }
  createWorkout(workout: CreateWorkout): Observable<CreateWorkout> {
    return this.http.post<CreateWorkout>('https://localhost:7282/api/Workouts', workout);
  }
  getWorkoutsByUserId(id: string): Observable<CreateWorkout[]> {
    return this.http.get<CreateWorkout[]>(`https://localhost:7282/api/Workouts/${id}/user-workouts`);
  }

  addUserExerciseToWorkout(userExerciseId: string, workoutId: string, ex: UserExercise): Observable<UserExercise> {
    return this.http.post<UserExercise>(`https://localhost:7282/api/UserExcercises/${userExerciseId}/workouts/${workoutId}`, ex)
  }

  getWorkoutsExercises(workoutId: string): Observable<UserExercise[]> {
    return this.http.get<UserExercise[]>(`https://localhost:7282/api/Workouts/${workoutId}/user-exercises`);
  }
  getExerciseById(exerciseId: string): Observable<Exercise> {
    return this.http.get<Exercise>(`https://localhost:7282/api/Exercises/${exerciseId}`)
  }

  deleteWorkout(workoutId: string): Observable<any> {
    return this.http.delete(`https://localhost:7282/api/Workouts/${workoutId}`);
  }
  updateExercise(id: string, updatedExercise: Exercise): Observable<Exercise> {
    return this.http.put<Exercise>(`https://localhost:7282/api/Exercises/${id}`, updatedExercise);
  }
  updateWorkout(id: string, updatedWorkout: CreateWorkout): Observable<CreateWorkout> {
    return this.http.put<CreateWorkout>(`https://localhost:7282/api/Workouts/${id}`, updatedWorkout);
  }

}
