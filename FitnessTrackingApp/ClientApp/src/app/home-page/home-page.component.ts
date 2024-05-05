import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data-service/data.service';
import { TestModel } from '../models/TestModel';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  randomData: TestModel[] = [];

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.dataService.getRandomData().subscribe((data: TestModel[]) => {
      this.randomData = data;
    });
  }
}
