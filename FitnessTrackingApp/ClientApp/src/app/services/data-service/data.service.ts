import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TestModel } from '../../models/TestModel';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  getRandomData(): Observable<TestModel[]> {
    return this.http.get<TestModel[]>('https://api.github.com/users');
  }
}
